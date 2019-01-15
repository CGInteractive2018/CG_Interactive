using UnityEngine;
using System.Collections;
using UnityEngine.UI;  ////ここを追加////
using System;

public class ScoreText : MonoBehaviour
{
    private float timeOut = 3.0f;
    float timeElapsed = 0;
    public static int hitCount = 0;
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
        
        //this.GetComponent<TextMesh>().text = "" + timeElapsed;
        timeElapsed += Time.deltaTime;
        
        if (timeElapsed >= timeOut)
        {
            //this.GetComponent<TextMesh>().text = "";
            //残弾数の表示
            this.GetComponent<TextMesh>().text = "remaining ammo : " + SpGenerator.remain;
            timeElapsed = 0.0f;
        }


        if (HitPlayer.hitflag == 1)
        {
            //this.GetComponent<Text>().text = "Hit2!!";
            ScoreText.hitCount++;
            hitCount2++;
            this.GetComponent<TextMesh>().text = "  Hit2!!" + Environment.NewLine + "hitCount : " + hitCount2;
            if (ScoreText.hitCount == 2)
            {
                HitPlayer.hitflag = 0;
                ScoreText.hitCount = 0;
            }
            timeElapsed = 0.0f;
        }
        else if (HitPlayer2.hitflag2 == 1)
        {
            //this.GetComponent<Text>().text = "Hit1!!";
            ScoreText.hitCount++;
            hitCount1++;
            this.GetComponent<TextMesh>().text = "  Hit1!!" + Environment.NewLine + "hitCount : " + hitCount1;
            if (ScoreText.hitCount == 2)
            {
                HitPlayer2.hitflag2 = 0;
                ScoreText.hitCount = 0;
            }
            timeElapsed = 0.0f;
        }
    }
}