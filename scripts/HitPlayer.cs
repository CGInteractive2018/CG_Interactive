using UnityEngine;
using System.Collections;
using UnityEngine.UI;//この宣言が必要

public class HitPlayer : MonoBehaviour
{
    public static int hitflag = 0;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Player2")
        {
            HitPlayer.hitflag = 1;
        }
    }
}