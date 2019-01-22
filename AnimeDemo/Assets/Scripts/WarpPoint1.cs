using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint1 : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3(43,26,-18);
        }
    }
}



        


