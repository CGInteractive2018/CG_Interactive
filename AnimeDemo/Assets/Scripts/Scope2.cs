using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope2 : MonoBehaviour
{
    public int n;
    private float rotX;
    private float rotY;
    public float RotationSensitivity = 100f;//感度
    public float SlideDistanceM = 0f;
    public Transform target;
    public float HeightM = 1.2f;
    public GameObject player;
    public GameObject thirdPersonCamera;
    public float DistanceToPlayerM = 2f;    // カメラとプレイヤーとの距離[m]

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        var controllerNames = Input.GetJoystickNames()[1];

        if (controllerNames == "Wireless Gamepad")
        {
            n = 1;
        }
        else if (controllerNames == "Wireless Controller")
        {
            n = 2;
        }

        if (n == 1)
        {
            rotX = Input.GetAxis("R_XAxis_2") * Time.deltaTime * RotationSensitivity;
            rotY = Input.GetAxis("R_YAxis_2") * Time.deltaTime * RotationSensitivity;
        }
        else if (n == 2)
        {
            rotX = Input.GetAxis("R_XAxis_2_PS") * Time.deltaTime * RotationSensitivity;
            rotY = Input.GetAxis("R_YAxis_2_PS") * Time.deltaTime * RotationSensitivity;
        }

        if (transform.forward.y > 0.9f && rotY < 0)
        {
            rotY = 0;
        }
        if (transform.forward.y < -0.9f && rotY > 0)
        {
            rotY = 0;
        }

        var lookAt = target.position + Vector3.up * HeightM;
        player.transform.RotateAround(lookAt, Vector3.up, rotX);
        transform.RotateAround(lookAt, transform.right, rotY);

        //回転
        //thirdPersonCamera.transform.RotateAround(lookAt, Vector3.up, rotX);
        // カメラがプレイヤーの真上や真下にあるときにそれ以上回転させないようにする
        if (thirdPersonCamera.transform.forward.y > 0.9f && rotY < 0)
        {
            rotY = 0;
        }
        if (thirdPersonCamera.transform.forward.y < -0.9f && rotY > 0)
        {
            rotY = 0;
        }
        thirdPersonCamera.transform.RotateAround(lookAt, transform.right, rotY);

        // カメラとプレイヤーとの間の距離を調整
        thirdPersonCamera.transform.position = lookAt - thirdPersonCamera.transform.forward * DistanceToPlayerM;

        // 注視点の設定
        thirdPersonCamera.transform.LookAt(lookAt);

        // カメラを横にずらして中央を開ける
        thirdPersonCamera.transform.position = thirdPersonCamera.transform.position + thirdPersonCamera.transform.right * SlideDistanceM;
    }
}
