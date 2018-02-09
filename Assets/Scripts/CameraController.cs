using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = target.position - this.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = target.position + offset;
		transform.LookAt (target);

	}
}
