using UnityEngine;
using UnityEngine.Networking;

public class ShipController : NetworkBehaviour
{
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public Rigidbody rb;
	public Transform t; 
	public float thrust = 2;
	public float turnspeed = 30;
	public float rotationX = 0;
	public float rotationY = 0;
	public float rotationZ = 0;

	Vector3 LookAtPos;
	Vector3 SmoothedLookAtPos;

	void Start () {

		rb = GetComponent<Rigidbody>();
		t = GetComponent<Transform> ();
		rotationX = t.rotation.x;
		rotationY = t.rotation.y;
		rotationZ = t.rotation.z;


	}

	void FixedUpdate()
	{
		if (!isLocalPlayer)
		{
			return;
		}






		//This line makes it point at 0,0
		//SmoothedLookAtPos = Vector3.Lerp(SmoothedLookAtPos, LookAtPos, Time.deltaTime * 5);
		//if x>88 

		//else 
		transform.LookAt(SmoothedLookAtPos, transform.up);
		//Quaternion rotation = Quaternion.LookRotation(SmoothedLookAtPos, new Vector3(0,1,0));
		//transform.rotation = rotation;

		//Move forward (you could use a Rigidbody)
		//transform.position += transform.forward * Time.deltaTime * thrust;
		/*
		if (Input.GetButtonDown ("Vertical")) {
			rb.AddRelativeForce (Vector3.forward * -thrust);
		}
		*/

		float speed = Input.GetAxisRaw ("Vertical"); //* Time.deltaTime;

		float rotation = Input.GetAxisRaw ("Horizontal");

		Debug.Log ("rotation=" + rotation + " speed=" + speed);
		/*
		if (Input.GetAxisRaw("Horizontal") > 0) {
			print ("right pressed");
			rotationZ = rotationZ - 1 ;
		}

		if (Input.GetAxisRaw("Horizontal") < 0) {
			print ("left pressed");
			rotationZ = rotationZ + 1 ;
		}

*/
		Vector3 rf = Vector3.forward * speed * thrust;
		//Debug.Log ("relative force " + rf);
		Vector3 pos = rb.position;
		Debug.Log ("current pos = " + pos);
		if (speed == 1) {
			pos.z += 0.01f;
		} else if(speed == -1) {
			pos.z -= 0.01f;
		}
		Debug.Log ("new pos = " + pos);	

		rb.transform.Translate (pos);
		//rb.AddRelativeForce (rf);
		t.Rotate (0f, 0f, rotationZ + rotation);


		if (Input.GetKey(KeyCode.Space))
		{
			CmdFire();
		}

	}


		//This is for shooting, not needed atm.
		//
		



	[Command]
	void CmdFire()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);      

		NetworkServer.Spawn (bullet);
	}

	public override void OnStartLocalPlayer ()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
}
