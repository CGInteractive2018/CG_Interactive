using UnityEngine;
using System.Collections;
using UnityEngine.UI;  ////ここを追加////
using System;

public class ScoreText : MonoBehaviour
{
    private float timeOut = 3.0f;
    float timeElapsed = 0;
    int hitCount1 = 0;
    int hitCount2 = 0;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<TextMesh>().text = "test";
    }

    // Update is called once per frame
    private void Update()
    {
        this.GetComponent<TextMesh>().text = "" + timeElapsed;
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            this.GetComponent<TextMesh>().text = "";
            timeElapsed = 0.0f;
        }

        if (HitPlayer.hitflag == 1)
        {
            //this.GetComponent<Text>().text = "Hit2!!";
            hitCount2++;
            this.GetComponent<TextMesh>().text = "  Hit2!!" + Environment.NewLine + "hitCount : " + hitCount2;
            HitPlayer.hitflag = 0;
            timeElapsed = 0.0f;
        }
        if (HitPlayer2.hitflag2 == 1)
        {
            //this.GetComponent<Text>().text = "Hit1!!";
            hitCount1++;
            this.GetComponent<TextMesh>().text = "  Hit1!!" + Environment.NewLine + "hitCount : " + hitCount1;
            HitPlayer2.hitflag2 = 0;
            timeElapsed = 0.0f;
        }
    }
}