using UnityEngine;
using System.Collections;

public class PortalStopCamera : MonoBehaviour {
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			Camera.main.GetComponent<CameraController>().disablePointerFeature();
		}
	}
}
