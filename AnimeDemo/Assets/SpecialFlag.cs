﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialFlag : MonoBehaviour
{
    public static bool special_flag1;

    // Start is called before the first frame update
    void Start()
    {
        special_flag1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 3")) {
            if (special_flag1 == false)
            {
                special_flag1 = true;
            }
            else
            {
                special_flag1 = false;
            }
        }
    }
}
