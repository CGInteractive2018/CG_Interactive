using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEXTforHUD2 : MonoBehaviour
{
    public GameObject camera;
    GameObject text;
    private Transform CamPos;
    private Vector3 Camforward;
    private float debug = 0.5f;
    private float debug2 = 0.35f;
    public float debug3;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindWithTag("TEXTforHUD2");
        debug = 0.5f;
        debug2 = 0.35f;
        //debug3 = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの向き取得
        CamPos = camera.transform;
        Camforward = Vector3.Scale(CamPos.forward, new Vector3(1, 1, 1)).normalized;

        //位置をカメラの位置に
        var xpos = camera.transform.position.x;
        var ypos = camera.transform.position.y;
        var zpos = camera.transform.position.z;

        //x,zに対しての90どのべくとるをしゅとく
        var vec1 = Quaternion.Euler(0f, -90f, 0f) * Camforward;

        Vector3 pos = new Vector3(xpos + Camforward.x * debug + vec1.x * debug2, ypos + Camforward.y * debug - debug3, zpos + Camforward.z * debug + vec1.z * debug2);

        text.transform.position = pos;
    }
}
