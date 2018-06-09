﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class bird : MonoBehaviour
{
    public float tapForce = 10;
    public float tiltSmooth = 5;
    public Vector3 startPos;

    Rigidbody2D rigidbody;
    Quaternion downRotation;
    Quaternion forwardRotation;

    void start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.rotation = forwardRotation;
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);

        }

        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);

    }
    
}
