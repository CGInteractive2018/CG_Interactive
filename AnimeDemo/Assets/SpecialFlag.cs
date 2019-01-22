using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialFlag : MonoBehaviour
{
    public static bool special_flag1;
    public static bool special_flag2;
    public GameObject weapon1_1;
    public GameObject weapon1_2;
    public GameObject weapon2_1;
    public GameObject weapon2_2;


    // Start is called before the first frame update
    void Start()
    {
        special_flag1 = false;
        special_flag2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("X1")) {
            weapon1_1.SetActive(!weapon1_1.activeInHierarchy);
            weapon1_2.SetActive(!weapon1_2.activeInHierarchy);
            Debug.Log("Push X");
            if (special_flag1 == false)
            {
                special_flag1 = true;
            }
            else
            {
                special_flag1 = false;
            }
        }
        if (Input.GetButtonDown("X2"))
        {
            weapon2_1.SetActive(!weapon2_1.activeInHierarchy);
            weapon2_2.SetActive(!weapon2_2.activeInHierarchy);
            Debug.Log("Push X");
            if (special_flag2 == false)
            {
                special_flag2 = true;
            }
            else
            {
                special_flag2 = false;
            }
        }
    }
}
