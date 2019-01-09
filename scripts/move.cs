using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    public float maxSpeed;
    public float runSpeed;
    private bool isGround = true;


    // Use this for initialization
    void Start()
    {
        rigidbody = this.transform.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            if (rigidbody.velocity.magnitude < maxSpeed)
            {
                rigidbody.AddForce(transform.forward * runSpeed);
            }
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey("down"))
        {
            if (rigidbody.velocity.magnitude < maxSpeed)
            {
                rigidbody.AddForce(-transform.forward * runSpeed);
            }
        }
        else{
            animator.SetBool("isRunning", false);
        }
        if (Input.GetKey("right"))
        {
            if (rigidbody.velocity.magnitude < maxSpeed)
            {
                rigidbody.AddForce(transform.right * runSpeed);
            }
            animator.SetBool("isRunningRight", true);
        }
        else if (Input.GetKey("left"))
        {
            if (rigidbody.velocity.magnitude < maxSpeed)
            {
                rigidbody.AddForce(-transform.right * runSpeed);
            }
        }
        else{
            animator.SetBool("isRunningRight", false);
        }
    }
}