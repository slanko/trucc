﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compassScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, -Input.compass.magneticHeading, 0);
    }
}
