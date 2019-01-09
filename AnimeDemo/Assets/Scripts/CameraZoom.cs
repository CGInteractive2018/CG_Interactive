using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    private Camera cam;
    private float varX;
    private int flag;
    float view;

    void Start()
    {
        cam = GetComponent<Camera>();
        flag = 0;
        float view = cam.fieldOfView - 30f;
        cam.fieldOfView = Mathf.Clamp(value: view, min: 0.1f, max: 45f);
    }

    void Update()
    {
    }
}
