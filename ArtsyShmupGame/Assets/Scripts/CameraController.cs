using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float horizontalSpeed = 2f;
	public float verticalSpeed = 2f;

	private float camRayLength = 100f;
	
	// Update is called once per frame
	void Update () {
		//This will get the position of the mouse
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		//We check that there was a hit
		if (Physics.Raycast (camRay, out hit, camRayLength)) {//The mouse was in the screen and we have the coordinates
			float horizontal = (hit.point.x > transform.position.x)? 1 : (hit.point.x < transform.position.x) ? -1 : 0;
			float vertical = (hit.point.y > transform.position.y) ? 1 : (hit.point.y < transform.position.y) ? -1 : 0;
		}
	}
}
