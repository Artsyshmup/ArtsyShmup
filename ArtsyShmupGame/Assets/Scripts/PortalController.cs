using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {
	private bool used = false;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!used && other.tag == "Player") {
			used = true;
			Camera.main.GetComponent<LevelManager>().FinishLevel();
		}
	}
}
