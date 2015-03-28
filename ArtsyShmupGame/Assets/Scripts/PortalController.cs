using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Camera.main.GetComponent<LevelManager>().FinishLevel();
		}
	}
}
