using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sp1Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 tmp = this.transform.position;
        if(tmp.y < -5)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;
        if (name == "Player2")
        {
            Debug.Log("Collision!");
        }
    }
}
