using UnityEngine;
using System.Collections;

public class PortalStopCamera : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (renderer.isVisible) {
			Camera.main.GetComponent<CameraController>().disablePointerFeature();
		}
	}
}
