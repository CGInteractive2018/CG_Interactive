﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;//この宣言が必要

public class AmmoBox : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0);
            SpGenerator.remain += 10;
        }
        if (otherObj.gameObject.tag == "Player2")
        {
            Destroy(gameObject, 0);
            SpGenerator2.remain += 10;
        }
    }
}
