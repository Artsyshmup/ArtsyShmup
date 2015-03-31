using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float horizontalSpeed = 2f;
	public float verticalSpeed = 2f;
	public float smoothing = 5;
	public float mouse_x_offset = 4f;
	public float mouse_y_offset = 4f;
	public Transform target;
	private Vector3 offset;
	private bool pointerFeature = true;

	private float camRayLength = 100f;

	void Start(){
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 targetCameraPosition;
		if (pointerFeature) {
			targetCameraPosition = target.position + offset;
			//This will get the position of the mouse
			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			//We check that there was a hit
			if (Physics.Raycast (camRay, out hit, camRayLength)) {//The mouse was in the screen and we have the coordinates
				float horizontal = (hit.point.x > (transform.position.x + mouse_x_offset)) ? 1 : (hit.point.x < (transform.position.x - mouse_x_offset)) ? -1 : 0;
				float vertical = (hit.point.y > (transform.position.y + mouse_y_offset)) ? 1 : (hit.point.y < (transform.position.y - mouse_y_offset)) ? -1 : 0;
				Vector2 movement = new Vector2 (horizontal * horizontalSpeed, vertical * verticalSpeed);
				targetCameraPosition += movement;
			}
		} else {
			targetCameraPosition = new Vector2();
			targetCameraPosition.y = target.position.y + offset.y;
			targetCameraPosition.x = transform.position.x;
		}
		transform.position = Vector2.Lerp (transform.position, targetCameraPosition, smoothing * Time.deltaTime);
	}

	public void disablePointerFeature()
	{
		this.pointerFeature = false;
	}
}
