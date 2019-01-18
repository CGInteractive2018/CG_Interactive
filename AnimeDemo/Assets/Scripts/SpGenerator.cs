using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpGenerator : MonoBehaviour {

    public GameObject Sphere;
    public GameObject effect;
    public float spn = 1.0f;
    float dlt = 0;
    GameObject target;
    GameObject camera;
    public float high = 1f;
    public float bulletPower = 1000f;
    public static int remain;
    //銃撃音
    public AudioClip audioClip1;
    private AudioSource audioSource;


    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player");
        camera = GameObject.FindWithTag("MainCamera");
        remain = 10;
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
        heading.y = (target.transform.position.y + 1) - camera.transform.position.y;

        //方向ベクトルの正規化        
        var distance = heading.magnitude;
        var direction = heading / distance;

        this.dlt += Time.deltaTime;
        //if (Input.GetKeyDown("joystick button 7"))
        if (remain != 0)
        {
            if (Input.GetButtonDown("ZR"))
            {
                //プレイヤーの向きの正規化
                direction.Normalize();

                Vector3 pos = new Vector3(xpos + direction.x, 1.1f, zpos + direction.z);

                GameObject bullet = Instantiate(Sphere, pos, Quaternion.identity);
                GameObject MazzuleFlash = Instantiate(effect, pos, Quaternion.identity);
                MazzuleFlash.transform.rotation = target.transform.rotation;
                MazzuleFlash.transform.Rotate(new Vector3(0.0f, 90f, 0.0f));
                Rigidbody rd = bullet.transform.GetComponent<Rigidbody>();
                rd.AddForce(direction.x * bulletPower, direction.y * bulletPower, direction.z * bulletPower);

                //銃撃音の再生
                audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.clip = audioClip1;
                audioSource.Play();

                remain--;
            }
        }
    }
}
