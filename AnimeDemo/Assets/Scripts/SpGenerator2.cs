using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpGenerator2 : MonoBehaviour
{
    private GameObject bullet;
    public GameObject Special_Bullet;
    public GameObject Sphere;
    public GameObject effect;
    public float spn = 1.0f;
    float dlt = 0;
    GameObject target;
    GameObject camera;
    public float high = 1f;
    public float bulletPower = 1000f;
    public static int remain;
    public static int special_remain;

    //カメラの向き取得
    private Transform CamPos;
    private Vector3 Camforward;
    //銃撃音
    public AudioClip audioClip1;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player2");
        camera = GameObject.FindWithTag("Camera2");
        special_remain = 0;
        remain = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの向き取得
        CamPos = camera.transform;
        Camforward = Vector3.Scale(CamPos.forward, new Vector3(1, 1, 1)).normalized;

        float xpos = target.transform.position.x;
        float ypos = target.transform.position.y;
        float zpos = target.transform.position.z;

        //カメラの現在位置取得
        Vector3 cpos = camera.transform.position;
        //z軸の設定
        cpos.z = 0f;


        //球を飛ばす方向ベクトルの取得
        var heading = target.transform.position - camera.transform.position;
        heading.y = (target.transform.position.y + 3) - camera.transform.position.y;

        //方向ベクトルの正規化        
        var distance = heading.magnitude;
        var direction = heading / distance;


        this.dlt += Time.deltaTime;
        //if (Input.GetKeyDown("joystick button 7"))
        if (remain >= 0 && special_remain >= 0)
        {
            if (Input.GetButtonDown("ZR2"))
            {
                //正規化
                direction.Normalize();

                Vector3 pos = new Vector3(xpos + direction.x, ypos + direction.y, zpos + direction.z);
                //スペシャル状態の時
                if (SpecialFlag.special_flag2 == true && special_remain >= 1)
                {
                    GameObject bullet = Instantiate(Special_Bullet, pos, Quaternion.identity);
                    Rigidbody rd = bullet.transform.GetComponent<Rigidbody>();
                    rd.AddForce(Camforward * bulletPower);
                    special_remain--;
                    GameObject MazzuleFlash = Instantiate(effect, pos, Quaternion.identity);
                    MazzuleFlash.transform.rotation = target.transform.rotation;
                    MazzuleFlash.transform.Rotate(new Vector3(0.0f, 90f, 0.0f));

                    //銃撃音の再生
                    audioSource = gameObject.GetComponent<AudioSource>();
                    audioSource.clip = audioClip1;
                    audioSource.Play();
                }
                //そうでないとき
                else if(SpecialFlag.special_flag2 == false && remain >= 1)
                {
                    GameObject bullet = Instantiate(Sphere, pos, Quaternion.identity);
                    Rigidbody rd = bullet.transform.GetComponent<Rigidbody>();
                    rd.AddForce(Camforward * bulletPower);
                    remain--;
                    GameObject MazzuleFlash = Instantiate(effect, pos, Quaternion.identity);
                    MazzuleFlash.transform.rotation = target.transform.rotation;
                    MazzuleFlash.transform.Rotate(new Vector3(0.0f, 90f, 0.0f));

                    //銃撃音の再生
                    audioSource = gameObject.GetComponent<AudioSource>();
                    audioSource.clip = audioClip1;
                    audioSource.Play();
                }
            }
        }
    }
}
