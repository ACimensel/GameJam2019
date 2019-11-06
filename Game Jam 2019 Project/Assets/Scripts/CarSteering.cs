using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering : MonoBehaviour {

    private Rigidbody rb;

	[SerializeField]
	private float accelerationPower = 100f;
	[SerializeField]
    private float steeringPower = 2f;
    private float throttle, steer;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        steer = Input.GetAxis ("Horizontal");
        throttle = Input.GetAxis ("Vertical");

        if (throttle>0) {
            transform.Rotate(Vector3.up * steer * Mathf.Abs(steer) * steeringPower * throttle);
        }
        else if (throttle<0) {
            transform.Rotate(Vector3.up * steer * Mathf.Abs(steer) * steeringPower * throttle);
        }

        rb.AddRelativeForce(Vector3.forward * throttle * accelerationPower);//moves car forward
		//rb.AddRelativeForce( - Vector3.right * rb.velocity.magnitude * steeringAmount / 2);//moves car sideways
			
	}


}
