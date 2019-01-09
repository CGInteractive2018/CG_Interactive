using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanRunning : MonoBehaviour {

	private Animator animator;
	private Rigidbody rigitbody;
	private bool isGround = true;
	public float runSpeed;
	public float maxSpeed;
	public float jumpPower;
	public float ForceGravity = 100f;
	public float rotateSpeed = 1f;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rigitbody = this.transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up")) {
            // move by transform
//			transform.position += transform.forward * runSpeed;
			if (rigitbody.velocity.magnitude < maxSpeed) {
				rigitbody.AddForce (transform.forward * runSpeed);
			}
			animator.SetBool ("is_running", true);
		} 
		else if (Input.GetKey ("down")) {
			if (rigitbody.velocity.magnitude < maxSpeed*0.2f) {
				rigitbody.AddForce (-transform.forward * runSpeed);
			}
			animator.SetBool ("is_backwalking", true);
		}
		else {
			if (rigitbody.velocity.magnitude > maxSpeed*0.01f) {
				rigitbody.AddForce (-rigitbody.velocity * runSpeed*0.5f);
			}
			animator.SetBool ("is_running", false);
			animator.SetBool ("is_backwalking", false);
		}
		if (Input.GetKey ("right")) {
			transform.Rotate (0, rotateSpeed, 0);
		}
		if (Input.GetKey ("left")) {
			transform.Rotate (0, -rotateSpeed, 0);
		}
		if (isGround && Input.GetKeyDown ("space")) {
			rigitbody.AddForce (transform.up * jumpPower);
			animator.SetBool ("is_jumping", true);
		}
	}

//	void FixedUpdate() {
//		rigitbody.AddForce (Vector3.down * ForceGravity, ForceMode.Acceleration);
//	}

	void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Ground") {
			isGround = true;
			animator.SetBool ("is_jumping", false);
		}
	}
	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == "Ground") {
			isGround = false;

		}
	}
}
