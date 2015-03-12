using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float horizontalSpeed = 2f;
	public float verticalSpeed = 2f;
	public float smoothing = 5;
	public Transform target;
	private Vector3 offset;

	private float camRayLength = 100f;

	void Start(){
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		//This will get the position of the mouse
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		Vector2 targetCameraPosition = target.position + offset;
		//We check that there was a hit
		if (Physics.Raycast (camRay, out hit, camRayLength)) {//The mouse was in the screen and we have the coordinates
			float horizontal = (hit.point.x > transform.position.x)? 1 : (hit.point.x < transform.position.x) ? -1 : 0;
			float vertical = (hit.point.y > transform.position.y) ? 1 : (hit.point.y < transform.position.y) ? -1 : 0;
			Vector2 movement = new Vector2(horizontal * horizontalSpeed, vertical * verticalSpeed);
			targetCameraPosition += movement;
		}

		transform.position = Vector2.Lerp (transform.position, targetCameraPosition, smoothing * Time.deltaTime);
	}
}
