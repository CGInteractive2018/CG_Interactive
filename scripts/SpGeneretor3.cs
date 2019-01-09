﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpGeneretor3 : MonoBehaviour
{

    public GameObject Sphere;
    public float spn = 1.0f;
    float dlt = 0;
    public GameObject target;
    public GameObject camera;
    public float high = 1f;
    public float bulletPower = 1000f;
    // Use this for initialization
    void Start()
    {
        //target = GameObject.FindWithTag("Player");
        //camera = GameObject.FindWithTag("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        float xpos = target.transform.position.x;
        float ypos = target.transform.position.y;
        float zpos = target.transform.position.z;

        //カメラの現在位置取得
        Vector3 cpos = camera.transform.position;
        //z軸の設定
        cpos.z = 0f;


        //球を飛ばす方向ベクトルの取得
        var heading = target.transform.position - camera.transform.position;

        //方向ベクトルの正規化        
        var distance = heading.magnitude;
        var direction = heading / distance;


        if (Input.GetButtonDown("ProCon1_ZR_button") == true)
        {
            Vector3 pos = new Vector3(xpos, ypos + 1f, zpos);

            GameObject bullet = Instantiate(Sphere, pos, Quaternion.identity);
            Rigidbody rd = bullet.transform.GetComponent<Rigidbody>();
            rd.AddForce(direction.x * bulletPower, 0, direction.z * bulletPower);
        }

    }
}
