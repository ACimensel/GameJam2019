using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Camera cam;
    private Rigidbody rb; //do i need?
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Transform myTransform;

    private bool grounded = false;
    private float speed;

    public float walkSpeed = 6.0f;
    public float runSpeed = 11.0f;
    public float turnSpd = 5.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    // Use this for initialization
    void Start () {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        myTransform = transform;
        speed = runSpeed;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        float inputX = Input.GetAxis("Horizontal");
        //float inputY = Input.GetAxis("Vertical");

        // Apply gravity
        //moveDirection.y -= gravity * Time.deltaTime;

        //Makes player move forward at a constant speed
        transform.Translate(0f, 0f, runSpeed * Time.deltaTime);

        //Rotates the player using A and D
        transform.Rotate(0, inputX * turnSpd*20.0f * Time.deltaTime, 0);
        
        //Outputs what object was clicked on, in the main camera view
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
            }
        }
    }
}
