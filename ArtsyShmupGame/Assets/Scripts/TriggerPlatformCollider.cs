using UnityEngine;
using System.Collections;

public class TriggerPlatformCollider : MonoBehaviour {
	private PlatformController platformController;
	private BoxCollider2D collider;

	void Start()
	{
		collider = GetComponent<BoxCollider2D> ();
		platformController = transform.parent.gameObject.GetComponent<PlatformController> ();
		transform.position = new Vector2 (
			transform.parent.position.x,
			transform.parent.position.y + collider.size.y/2);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			platformController.SpawnNewPlatform();
			Destroy (gameObject);
		}
	}
}
