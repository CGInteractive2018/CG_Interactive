using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint6 : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3(23, 1, 16);
        }
    }
}
