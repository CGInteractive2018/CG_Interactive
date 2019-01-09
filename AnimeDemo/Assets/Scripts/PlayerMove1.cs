using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour {

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
    public float jumpPower;

    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        varX = Input.GetAxis("Axis 2");
        varZ = -Input.GetAxis("Axis 4");
        a = Mathf.Atan(varZ / varX) * 180 / Mathf.PI;
        Debug.Log(isGround);

        if(varX.Equals(0) == false || varZ.Equals(0) == false)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
        if (isGround && Input.GetKeyDown("joystick button 0"))
        {
            rb.AddForce(transform.up * jumpPower);
            animator.SetBool("is_jumping", true);
        }





    }
    void FixedUpdate(){
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
        

    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("is_jumping", false);
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = false;

        }
    }

}
