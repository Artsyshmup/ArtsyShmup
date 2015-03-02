using UnityEngine;
using System.Collections;

public class PlayerFallManager : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			PlayerController playerController = other.GetComponent<PlayerController>();
			playerController.Die();
		}
	}
}
