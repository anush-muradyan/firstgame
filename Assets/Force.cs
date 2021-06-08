using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Force : MonoBehaviour
{
    public Rigidbody2D r;
    // Update is called once per frame

    private void Start()
    {
        r.AddForce(Random.insideUnitCircle*1000f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            r.AddForce(Random.insideUnitCircle * 150f);
        }
    }
}
