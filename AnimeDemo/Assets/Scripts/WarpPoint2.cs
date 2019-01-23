using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint2: MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player"||col.tag=="Player2")
        {
            col.gameObject.transform.position = new Vector3(-55, 26, 15);
        }
    }
}