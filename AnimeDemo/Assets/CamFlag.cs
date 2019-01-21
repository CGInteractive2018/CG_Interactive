using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFlag : MonoBehaviour
{
    public static bool camflag1;
    public static bool camflag2;


    // Start is called before the first frame update
    void Start()
    {
        camflag1 = true;
        camflag2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ZL"))
        {
            if (camflag1 == true) {
                camflag1 = false;
            }
            else
            {
                camflag1 = true;
            }
        }
        if (Input.GetButtonDown("ZL2"))
        {
            if (camflag2 == true)
            {
                camflag2 = false;
            }
            else
            {
                camflag2 = true;
            }
        }
    }
}
