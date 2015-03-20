using UnityEngine;
using System.Collections;

public class TriggerPlatformCollider : MonoBehaviour {
	private PlatformController platformController;
	private BoxCollider2D collider;
	private int parent_id;

	void Start()
	{
		collider = GetComponent<BoxCollider2D> ();
		platformController = transform.parent.gameObject.GetComponent<PlatformController> ();
		transform.position = new Vector2 (
			transform.parent.position.x,
			transform.parent.position.y + collider.size.y/2);
		parent_id = transform.parent.gameObject.GetComponent<PlatformController> ().platform_id;
		if (parent_id < PlatformController.platformsPerLevel) {
			gameObject.tag = "PlatformForward";
		} else {
			gameObject.tag = "PlatformBackward";
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			if(parent_id == PlatformController.platformsPerLevel){ //Time to go back
				for(int i=PlatformController.oldest_platform_id; i<parent_id; i++){
					platformController.DestroyOldPlatform(i);
				}
			}
			if(parent_id == 2*PlatformController.platformsPerLevel){ //Reached the end of the level
				Camera.main.GetComponent<LevelManager>().winLevel();
			}
			platformController.SpawnNewPlatform(gameObject.tag=="PlatformForward");
			Destroy (gameObject);
		}
	}
}
