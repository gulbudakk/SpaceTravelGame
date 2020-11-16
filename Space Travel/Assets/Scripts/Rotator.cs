﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0, speed) * Time.deltaTime);
    }
}
