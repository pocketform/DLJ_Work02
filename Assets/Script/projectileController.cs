﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    Rigidbody2D myRB;
    public float missleSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
            myRB.AddForce(new Vector2(-1, 0) * missleSpeed, ForceMode2D.Impulse);
        else
            myRB.AddForce(new Vector2(1, 0) * missleSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}
