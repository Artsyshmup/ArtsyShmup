using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float smoothing = 5;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}

	void FixedUpdate () {
		Vector2 targetCameraPosition = target.position + offset;
		transform.position = Vector2.Lerp (transform.position, targetCameraPosition, smoothing * Time.deltaTime);
	}
}
