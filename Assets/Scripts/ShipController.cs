using UnityEngine;
using UnityEngine.Networking;

public class ShipController : NetworkBehaviour {
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public Rigidbody rb;
	public Transform t;
	public float thrust = 2;
	public float turnspeed = 30;

	private Camera mainCamera;

	void Start () {

		mainCamera = Camera.main;

		rb = GetComponent<Rigidbody> ();
		t = GetComponent<Transform> ();
	}

	void FixedUpdate () {
		//		if (!isLocalPlayer) {
		//			return;
		//		}

		float speed = Input.GetAxisRaw ("Vertical"); //* Time.deltaTime;//
		float rotation = Input.GetAxisRaw ("Horizontal");

		Vector3 playerPos = t.position;
		playerPos.x = playerPos.x + 15;
		playerPos.z = playerPos.z + 15;
		playerPos.y = 10;
		mainCamera.transform.position = playerPos;
		mainCamera.transform.LookAt (t.localPosition);

		//float currentSpeed = rb.velocity.magnitude;
		Vector3 rf = Vector3.forward * thrust * speed;
		rb.AddRelativeForce (rf);
		t.Rotate (0f, t.rotation.z + rotation, 0f);

	}


	//This is for shooting, not needed atm.
	//
	[Command]
	void CmdFire () {
		// Create the Bullet from the Bullet Prefab
		//		var bullet = (GameObject)Instantiate (
		//			             bulletPrefab,
		//			             bulletSpawn.position,
		//			             bulletSpawn.rotation);
		//
		//		// Add velocity to the bullet
		//		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 6;
		//
		//		// Destroy the bullet after 2 seconds
		//		Destroy (bullet, 2.0f);      
		//
		//		NetworkServer.Spawn (bullet);
	}

	public override void OnStartLocalPlayer () {
		GetComponent<MeshRenderer> ().material.color = Color.blue;
	}
}
