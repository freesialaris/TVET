using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class tapController : MonoBehaviour
{
    public float tapForce = 30;
    public float tiltSmooth = 5;
    public Vector3 startPos;
    public GameObject bird;

    Rigidbody2D rigid;
    Quaternion downRotation;
    Quaternion forwardRotation;

    void start()
    {
        rigid = GetComponent<Rigidbody2D>();
        bird = GameObject.Find("Bird");
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bird.transform.rotation = forwardRotation;
            rigid.AddForce(Vector3.up * tapForce, ForceMode2D.Force);

        }

        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);

    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Score")
        {
            // score event
        }

        if (col.gameObject.tag == "Deadzone")
        {
            // end game, go to menu screen
            SceneManager.LoadScene("Menu");

        }
    }
}
