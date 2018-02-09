using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spaceship : MonoBehaviour {

	public Rigidbody rb;
	public Transform t; 
	public float thrust = 100;
	public float turnspeed = 30;
	public float rotationX = 0;
	public float rotationY = 0;
	public float rotationZ = 0;

	Vector3 LookAtPos;
	Vector3 SmoothedLookAtPos;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
		t = GetComponent<Transform> ();
		rotationX = t.rotation.x;
		rotationY = t.rotation.y;
		rotationZ = t.rotation.z;

	}

	// Update is called once per frame
	void Update () {


	}

	void FixedUpdate()
	{


		//Look At the Mouse
		LookAtPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000000));





		SmoothedLookAtPos = Vector3.Lerp(SmoothedLookAtPos, LookAtPos, Time.deltaTime * 5);
		//if x>88 

		//else 
		transform.LookAt(SmoothedLookAtPos, transform.up);
		//Quaternion rotation = Quaternion.LookRotation(SmoothedLookAtPos, new Vector3(0,1,0));
		//transform.rotation = rotation;

		//Move forward (you could use a Rigidbody)
		//transform.position += transform.forward * Time.deltaTime * thrust;
		if (Input.GetButtonDown ("Vertical")) {
			rb.AddRelativeForce (Vector3.forward * -thrust);
		}

		if (Input.GetAxisRaw("Vertical") > 0) {
			print ("forward pressed");
			rb.AddRelativeForce (Vector3.forward * thrust);
		}

		if (Input.GetAxisRaw("Vertical") < 0) {
			print ("reverse pressed");
			rb.AddRelativeForce (Vector3.forward * thrust);
		}

		if (Input.GetAxisRaw("Horizontal") > 0) {
			print ("right pressed");
			rotationZ = rotationZ - 1 ;
		}

		if (Input.GetAxisRaw("Horizontal") < 0) {
			print ("left pressed");
			rotationZ = rotationZ + 1 ;
		}

		t.Rotate (0f, 0f, rotationZ);

	}



}
