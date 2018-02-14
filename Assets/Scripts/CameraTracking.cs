using UnityEngine;
using UnityEngine.Networking;

public class CameraTracking : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		// do not camera track until player object is instantiated.
		if (player == null) {			
			player = GameObject.Find ("Spaceship");
		} 
		if (player != null) {						
			Vector3 playerPos = player.transform.position;
			playerPos.x = playerPos.x + 15;
			playerPos.z = playerPos.z + 15;
			playerPos.y = 10;
			transform.position = playerPos;
			transform.LookAt (player.transform.localPosition);
		}
	}
}
