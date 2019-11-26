using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Camera cam;
    private Rigidbody rb; //do i need?
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Transform myTransform; 
    private bool grounded = true;
    private float speed;
    private Animator animator;



    public Transform groundCheck;
    public float runSpeed = 11.0f;
    public float turnSpd = 5.0f;

    private float jumpSpeed = 22.0f;
    private float gravity = 30.0f;
    private float verticalVelocity;

    // Use this for initialization
    void Start () {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        myTransform = transform;
        speed = runSpeed;
    }

    // Update is called once per frame
    // Used for regular updates such as:
    // Moving non-physics objects
    // Simple Timers
    // Receiving Input
    // Update intervals may vary
    void Update()
    {
    }

    // Called every physics step
    // Fixedupdate intervals are consistent
    // Used for regular updates such as:
    // Adjusting physics (Rigidbody) objects
    void FixedUpdate ()
    {
        print(controller.isGrounded);

        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpSpeed;
                animator.SetTrigger("Jump");
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);

        //Makes player move forward at a constant speed
        float inputY = Input.GetAxis("Vertical");
        transform.Translate(0f, 0f, runSpeed * Time.deltaTime * inputY);

        //Rotates the player using A and D
        float inputX = Input.GetAxis("Horizontal");
        transform.Rotate(0, inputX * turnSpd*20.0f * Time.deltaTime, 0);
    }


    
}
