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
    private int remain;
    private int special_remain;
    private int life;
    public static bool alive;
    Slider slider;
    private Animator animator;
    private Animator animator2;
    private GameObject Player;
    private GameObject Player2;
    private GameObject Sp1;
    private GameObject Sp2;
    private GameObject Camera1;
    private GameObject Camera2;
    private GameObject Scope1;
    private GameObject Scope2;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<TextMesh>().text = "";
        life = 5;
        alive = true;
        slider = GameObject.Find("Slider2").GetComponent<Slider>();
        animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        animator2 = GameObject.FindWithTag("Player2").GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
        Player2 = GameObject.FindWithTag("Player2");
        Sp1 = GameObject.Find("SpGenerator");
        Sp2 = GameObject.Find("SpGenerator2");
        Camera1 = GameObject.Find("Main Camera");
        Camera2 = GameObject.Find("Camera2");
        Scope1 = GameObject.Find("ADS Camera1");
        Scope2 = GameObject.Find("ADS Camera2");
    }

    // Update is called once per frame
    private void Update()
    {
        if (ScoreText.alive == false)
        {
            this.GetComponent<TextMesh>().text = "You Are WINNER";
        }
        else if (life > 0)
        {
            //経過時間で表示を消す
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= timeOut)
            {
                //this.GetComponent<TextMesh>().text = "remaining ammo : " + SpGenerator2.remain;
                this.GetComponent<TextMesh>().text = "  life : " + life + "  Ammo : " + SpGenerator2.remain + "  Special Ammo : " + SpGenerator2.special_remain;
                remain = SpGenerator2.remain;
                special_remain = SpGenerator2.special_remain;
                timeElapsed = 0.0f;
            }

            if (remain != SpGenerator2.remain)
            {
                //this.GetComponent<TextMesh>().text = "remaining ammo : " + SpGenerator2.remain;
                this.GetComponent<TextMesh>().text = "  life : " + life + "  Ammo : " + SpGenerator2.remain + "  Special Ammo : " + SpGenerator2.special_remain;
                remain = SpGenerator2.remain;
                special_remain = SpGenerator2.special_remain;
            }

            if (special_remain != SpGenerator2.special_remain)
            {
                //this.GetComponent<TextMesh>().text = "remaining ammo : " + SpGenerator2.remain;
                this.GetComponent<TextMesh>().text = "  life : " + life + "  Ammo : " + SpGenerator2.remain + "  Special Ammo : " + SpGenerator2.special_remain;
                remain = SpGenerator2.remain;
                special_remain = SpGenerator2.special_remain;
            }

            //Player2に当たった時の処理
            if (HitPlayer.hitflag == 1)
            {
                //ライフを減少
                life--;
                slider.value -= 0.2f;
                //回数保存用
                ScoreText.hitCount++;
                hitCount2++;
                //書き換え
                //this.GetComponent<TextMesh>().text = "  Hit2!!" + Environment.NewLine + "hitCount : " + hitCount2;
                this.GetComponent<TextMesh>().text = "  life : " + life + "  Ammo : " + SpGenerator2.remain + "  Special Ammo : " + SpGenerator2.special_remain + Environment.NewLine + "  Hit2!!" + Environment.NewLine + "hitCount : " + hitCount2;
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
                //this.GetComponent<TextMesh>().text = "  Hit1!!" + Environment.NewLine + "hitCount : " + hitCount1;
                this.GetComponent<TextMesh>().text = "  life : " + life +  "  Ammo : " + SpGenerator.remain + "  Special Ammo : " + SpGenerator2.special_remain + Environment.NewLine + "  Hit1!!" + Environment.NewLine + "hitCount : " + hitCount1;
                if (ScoreText.hitCount == 2)
                {
                    HitPlayer2.hitflag2 = 0;
                    ScoreText.hitCount = 0;
                }
                timeElapsed = 0.0f;
            }
        }
        //死んだとき
        else
        {
            this.GetComponent<TextMesh>().text = "You Are DEAD";
            alive = false;
            animator.SetBool("Win", true);
            animator2.SetBool("Dead", true);
            Player.GetComponent<PlayerMove1_2>().enabled = false;
            Player2.GetComponent<PlayerMove2_2>().enabled = false;
            Sp1.GetComponent<SpGenerator>().enabled = false;
            Sp2.GetComponent<SpGenerator2>().enabled = false;
            Camera1.GetComponent<camera>().enabled = false;
            Camera2.GetComponent<camera2>().enabled = false;
            Camera1.GetComponent<Scope>().enabled = false;
            Camera2.GetComponent<Scope2>().enabled = false;
        }
    }
}