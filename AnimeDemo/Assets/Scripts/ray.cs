using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class ray : MonoBehaviour
{
    public static Vector3 point;

    void Start()
    {
        // スライダーを取得する

    }

    float _hp = 0;
    void Update()
    {
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(center);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000.0f)) {
           // Debug.Log(hit.point);
            point = hit.point;
        }
        else
        {

        }
    }
}