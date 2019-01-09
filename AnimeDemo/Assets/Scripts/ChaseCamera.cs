using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour {
	private GameObject player;
	private Vector3 prevPlayerPos;
	private Vector3 posVector;
	public float scale = 3.0f;
	public float cameraSpeed = 5.0f;
	public float cameraHeight = 1.5f;
	public float lookAtHeight = 1.5f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		prevPlayerPos = player.transform.position;
		posVector = this.transform.position.normalized;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPlayerPos = player.transform.position;
		Vector3 backVector = (prevPlayerPos - currentPlayerPos).normalized;
		if (true) {
			posVector = -player.transform.forward;
		} else {
			posVector = (backVector == Vector3.zero) ? posVector : backVector;
		}
		Vector3 targetPos = currentPlayerPos + scale * posVector;
		targetPos.y += cameraHeight;
		this.transform.position = Vector3.Lerp (
			this.transform.position,
			targetPos,
			cameraSpeed * Time.deltaTime
		);
		Vector3 lookAt = currentPlayerPos;
		lookAt.y += lookAtHeight;
		this.transform.LookAt (lookAt);
		prevPlayerPos = currentPlayerPos;

	}
}
