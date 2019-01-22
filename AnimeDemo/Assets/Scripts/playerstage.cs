using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerstage : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "MoveStage")
        {
            transform.SetParent(col.transform);
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "MoveStage")
        {
            transform.SetParent(null);
        }
    }
}
