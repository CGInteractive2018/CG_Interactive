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
    private int remain;
    private int life;
    public static bool alive;
    Slider slider;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<TextMesh>().text = "test";
        life = 5;
        alive = true;
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (ScoreText2.alive == false) {
            this.GetComponent<TextMesh>().text = "You Are WINNER";
        }
        else if (life > 0)
        {
            //this.GetComponent<TextMesh>().text = "" + timeElapsed;
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= timeOut)
            {
                //残弾数の表示
                this.GetComponent<TextMesh>().text = "  life : " + life + "  Ammo : " + SpGenerator.remain;
                remain = SpGenerator.remain;
                timeElapsed = 0.0f;
            }

            if (remain != SpGenerator.remain)
            {
                this.GetComponent<TextMesh>().text = "  life : " + life + "  Ammo : " + SpGenerator.remain;
                remain = SpGenerator.remain;
            }

            if (HitPlayer.hitflag == 1)
            {
                ScoreText.hitCount++;
                hitCount2++;
                this.GetComponent<TextMesh>().text = "  life : " + life + "  Ammo : " + SpGenerator.remain + Environment.NewLine + "  Hit2!!" + Environment.NewLine + "hitCount : " + hitCount2;
                if (ScoreText.hitCount == 2)
                {
                    HitPlayer.hitflag = 0;
                    ScoreText.hitCount = 0;
                }
                timeElapsed = 0.0f;
            }
            else if (HitPlayer2.hitflag2 == 1)
            {
                //ライフを減少
                life--;
                slider.value -=0.2f;

                ScoreText.hitCount++;
                hitCount1++;
                this.GetComponent<TextMesh>().text = "  life : " + life +  "  Ammo : " + SpGenerator.remain + Environment.NewLine + "  Hit1!!" + Environment.NewLine + "hitCount : " + hitCount1;
                if (ScoreText.hitCount == 2)
                {
                    HitPlayer2.hitflag2 = 0;
                    ScoreText.hitCount = 0;
                }
                timeElapsed = 0.0f;
            }
        }
        //死んだとき
        else {
            this.GetComponent<TextMesh>().text = "You Are DEAD";
            alive = false;
        }
    }
}