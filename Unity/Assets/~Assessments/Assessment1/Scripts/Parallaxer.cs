using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxer : MonoBehaviour
{
    class PoolObject
    {
        public Transform transform;
        public bool inUse;
        public PoolObject(Transform t) { transform = t; }
        public void Use() { inUse = true; }
        public void Dispose() { inUse = false; }
    }

    [System.Serializable]
    public struct YSpawnRange
    {
        public float min;
        public float max;
    }


    public GameObject Prefab;
    public int poolSize;
    public float shiftSpeed;
    public float spawnRate;

    public YSpawnRange ySpawnRange;
    public Vector3 defaultSpawnPos;
    public bool spawnImmediate;
    public Vector3 immediateSpawnPos;

    float spawnTimer;
    PoolObject[] poolObjects;

    void Awake()
    {
        Configure();
    }

    void Start()
    {

    }


    void Update()
    {
        Shift();
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnRate)
        {

            spawnTimer = 0;
        }
    }

    void Configure()
    {
        poolObjects = new PoolObject[poolSize];
        for (int i = 0; i < poolObjects.Length; i++)
        {
            GameObject go = Instantiate(Prefab) as GameObject;
            Transform t = go.transform;
            t.SetParent(transform);
            poolObjects[i] = new PoolObject(t);
        }

        if (spawnImmediate)
        {
            SpawnImmediate();
        }
    }


    void SpawnImmediate()
    {
        Transform t = GetPoolObject();
        if (t == null) return;
        Vector3 pos = Vector3.one;
        pos.x = immediateSpawnPos.x;
        pos.y = Random.Range(ySpawnRange.min, ySpawnRange.max);
        t.position = pos;

    }

    void Shift()
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            poolObjects[i].transform.localPosition += -Vector3.right * shiftSpeed;
            CheckDisposeObject(poolObjects[i]);
        }
    }

    void CheckDisposeObject(PoolObject poolObject)
    {
        if (poolObject.transform.position.x < -2.25)
        {
            poolObject.Dispose();
            poolObject.transform.position = Vector2.one;
            Vector3 pos = Vector3.one;

            SpawnImmediate();
        }
    }

    Transform GetPoolObject()
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            if (!poolObjects[i].inUse)
            {
                poolObjects[i].Use();
                return poolObjects[i].transform;
            }
        }
        return null;
    }
}
