using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Ground")
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
