using UnityEngine;
using System.Collections;
using UnityEngine.UI;  ////ここを追加////
using System;

public class ScoreText2 : MonoBehaviour
{
    private float timeOut = 3.0f;
    float timeElapsed = 0;
    //それぞれのヒット回数
    int hitCount1 = 0;
    int hitCount2 = 0;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<TextMesh>().text = "";
    }

    // Update is called once per frame
    private void Update()
    {
        //経過時間で表示を消す
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            //this.GetComponent<TextMesh>().text = "";
            this.GetComponent<TextMesh>().text = "remaining ammo : " + SpGenerator2.remain;
            timeElapsed = 0.0f;
        }

        //Player2に当たった時の処理
        if (HitPlayer.hitflag == 1)
        {
            //回数保存用
            ScoreText.hitCount++;
            hitCount2++;
            //書き換え
            this.GetComponent<TextMesh>().text = "  Hit2!!" + Environment.NewLine + "hitCount : " + hitCount2;
            //両方に表示するための処理
            if (ScoreText.hitCount == 2)
            {
                HitPlayer.hitflag = 0;
                ScoreText.hitCount = 0;
            }
            timeElapsed = 0.0f;
        }

        //Playerに当たった時の処理
        if (HitPlayer2.hitflag2 == 1)
        {
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