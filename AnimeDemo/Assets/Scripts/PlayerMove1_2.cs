using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1_2 : MonoBehaviour {
    //プレイヤー1を動かすスクリプト

    [SerializeField] private Vector3 velocity;              // 移動方向
    [SerializeField] private float moveSpeed = 5.0f;        // 移動速度
    private GameObject target;
    private float varX;
    private float varZ;
    private Rigidbody rb;
    private Animator animator;
    private bool isGround = true;
    private float a; //角度
    private Vector3 moveDirection;
    public float jumpPower = 10000;
    public int n;
    public static Vector3 playerForward1;
    public float state;


    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        var controllerNames = Input.GetJoystickNames()[0];
        
        if (controllerNames == "Wireless Gamepad") //プロコン
        {
            n = 1;
        }
        else if(controllerNames == "Wireless Controller")//PS4
        {
            n = 2;
        }


        if (n == 1)
        {
            varX = Input.GetAxis("L_XAxis_1");
            varZ = -Input.GetAxis("L_YAxis_1");
        }
        else if(n == 2)
        {
            varX = Input.GetAxis("L_XAxis_1_PS");
            varZ = -Input.GetAxis("L_YAxis_1_PS");
        }

        
        a = Mathf.Atan(varZ / varX) * 180 / Mathf.PI;

        if(varX.Equals(0) == false || varZ.Equals(0) == false)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
        if (isGround && Input.GetButtonDown("B1") && n == 1)
        {
            rb.AddForce(transform.up * jumpPower);
            animator.SetBool("is_jumping", true);
        }

        if (isGround && Input.GetButtonDown("B1_PS") && n == 2)
        {
            rb.AddForce(transform.up * jumpPower);
            animator.SetBool("is_jumping", true);
        }






    }
    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * varZ + Camera.main.transform.right * varX;


        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        if (System.Math.Abs(moveForward.x) > 0.1 || System.Math.Abs(moveForward.z) > 0.1)
        {
            playerForward1 = moveForward;
            state = moveForward.x;
        }
    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("is_jumping", false);
            animator.SetBool("isGround", true);
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = false;
            animator.SetBool("isGround",false);
        }
    }

}
