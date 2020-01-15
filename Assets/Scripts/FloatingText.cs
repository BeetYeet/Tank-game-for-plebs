﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float destroyTime;
    public Vector3 offset = new Vector3(5f, 1000, 0);

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);

        transform.localPosition += offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}