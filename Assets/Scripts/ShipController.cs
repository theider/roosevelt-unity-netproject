using UnityEngine;
using UnityEngine.Networking;

public class ShipController : NetworkBehaviour {
	
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public Rigidbody rigidBody;

	public float thrust = 2;
	public float turnspeed = 30;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		//		if (!isLocalPlayer) {
		//			return;
		//		}
		float speed = Input.GetAxisRaw ("Vertical"); //* Time.deltaTime;//
		float rotation = Input.GetAxisRaw ("Horizontal");

		Vector3 movementForce = Vector3.forward * thrust * speed;
		rigidBody.AddRelativeForce (movementForce);
		transform.Rotate (0f, transform.rotation.z + rotation, 0f);

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
