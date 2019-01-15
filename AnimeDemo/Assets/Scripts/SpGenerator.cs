using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpGenerator : MonoBehaviour {

    public GameObject Sphere;
    public float spn = 1.0f;
    float dlt = 0;
    GameObject target;
    GameObject camera;
    public float high = 1f;
    public float bulletPower = 1000f;
    public static int remain;
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

        //方向ベクトルの正規化        
        var distance = heading.magnitude;
        var direction = heading / distance;

        this.dlt += Time.deltaTime;
        //if (Input.GetKeyDown("joystick button 7"))
        if (remain != 0)
        {
            if (Input.GetButtonDown("ZR"))
            {
                this.dlt = 0;

                //プレイヤーの向きベクトル取得
                Vector3 vec = PlayerMove1_2.playerForward1;
                //正規化
                vec.Normalize();

                //球の出現位置
                Vector3 pos = new Vector3(xpos + vec.x, ypos + 1, zpos + vec.z);

                GameObject bullet = Instantiate(Sphere, pos, Quaternion.identity);
                Rigidbody rd = bullet.transform.GetComponent<Rigidbody>();
                rd.AddForce(vec.x * bulletPower, 0, vec.z * bulletPower);

                remain--;
            }
        }
        
    }
}
