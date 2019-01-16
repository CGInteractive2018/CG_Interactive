using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2_2 : MonoBehaviour
{
    //プレイヤー1を動かすスクリプト

    [SerializeField] private Vector3 velocity;              // 移動方向
    [SerializeField] private float moveSpeed = 5.0f;        // 移動速度
    private GameObject target;
    private float varX;
    private float varZ;
    private Rigidbody rb;
    private Animator animator;
    private bool isGround = true;
    private bool third = true;
    private float a; //角度
    private Vector3 moveDirection;
    public float jumpPower = 10000;
    public int n;
    public static Vector3 playerForward2;
    [SerializeField]
    public GameObject firstPersonCamera;   // インスペクターで主観カメラを紐づける
    [SerializeField]
    public GameObject thirdPersonCamera;   // インスペクターで第三者視点カメラを紐づける


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var controllerNames = Input.GetJoystickNames()[1];

        if (controllerNames == "Wireless Gamepad") //プロコン
        {
            n = 1;
        }
        else if (controllerNames == "Wireless Controller")//PS4
        {
            n = 2;
        }


        if (n == 1)
        {
            varX = Input.GetAxis("L_XAxis_2");
            varZ = -Input.GetAxis("L_YAxis_2");
        }
        else if (n == 2)
        {
            varX = Input.GetAxis("L_XAxis_2_PS");
            varZ = -Input.GetAxis("L_YAxis_2_PS");
        }

        Debug.Log(ScoreText2.alive);


        a = Mathf.Atan(varZ / varX) * 180 / Mathf.PI;


        if (isGround && Input.GetButtonDown("B2") && n == 1)
        {
            rb.AddForce(transform.up * jumpPower);
            animator.SetBool("is_jumping", true);
        }

        if (isGround && Input.GetButtonDown("B2_PS") && n == 2)
        {
            rb.AddForce(transform.up * jumpPower);
            animator.SetBool("is_jumping", true);
        }

        //animatorの設定
        //前方
        if (varX.Equals(0) == true && varZ > 0)
        {
            animator.SetBool("isRunning", true);
        }
        else if (varZ > 0 && Mathf.Atan(varZ / varX) < Mathf.PI / 2 && Mathf.Atan(varZ / varX) >= Mathf.PI / 4)
        {
            animator.SetBool("isRunning", true);
        }
        else if (varZ > 0 && Mathf.Atan(varZ / varX) > -Mathf.PI / 2 && Mathf.Atan(varZ / varX) <= -Mathf.PI / 4)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        //後方
        if (varX.Equals(0) == true && varZ < 0)
        {
            animator.SetBool("Buck", true);
        }
        else if (varZ < 0 && Mathf.Atan(varZ / varX) < Mathf.PI / 2 && Mathf.Atan(varZ / varX) >= Mathf.PI / 3)
        {
            animator.SetBool("Buck", true);
        }
        else if (varZ < 0 && Mathf.Atan(varZ / varX) > -Mathf.PI / 2 && Mathf.Atan(varZ / varX) <= -Mathf.PI / 3)
        {
            animator.SetBool("Buck", true);
        }
        else
        {
            animator.SetBool("Buck", false);
        }

        //右
        if (varX > 0 && Mathf.Atan(varZ / varX) < Mathf.PI / 3 && Mathf.Atan(varZ / varX) > -Mathf.PI / 3)
        {
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }

        //左
        if (varX < 0 && Mathf.Atan(varZ / varX) < Mathf.PI / 3 && Mathf.Atan(varZ / varX) > -Mathf.PI / 3)
        {
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }

        //カメラの切り替え
        if (Input.GetButtonDown("ZL2"))
        {
            // ↓現在のactive状態から反転 
            firstPersonCamera.SetActive(!firstPersonCamera.activeInHierarchy);
            thirdPersonCamera.SetActive(!thirdPersonCamera.activeInHierarchy);
            if (third == true)
            {
                third = false;
            }
            else
            {
                third = true;
            }
        }
        
        if (ScoreText2.alive == false)
        {
            animator.SetBool("Dead", true);
        }









    }
    void FixedUpdate()
    {
        if (third == true)
        {

            // カメラの方向から、X-Z平面の単位ベクトルを取得
            Vector3 cameraForward = Vector3.Scale(thirdPersonCamera.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * varZ + thirdPersonCamera.transform.right * varX;


            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

            if (System.Math.Abs(moveForward.x) > 0.1 || System.Math.Abs(moveForward.z) > 0.1)
            {
                playerForward2 = moveForward;
            }

        }
        if (third == false)
        {
            // カメラの方向から、X-Z平面の単位ベクトルを取得
            Vector3 cameraForward = Vector3.Scale(firstPersonCamera.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * varZ + firstPersonCamera.transform.right * varX;


            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);


            if (System.Math.Abs(moveForward.x) > 0.1 || System.Math.Abs(moveForward.z) > 0.1)
            {
                playerForward2 = moveForward;
            }

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
            animator.SetBool("isGround", false);
        }
    }

}
