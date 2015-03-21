using UnityEngine;
using System.Collections;

public class TriggerPlatformCollider : MonoBehaviour {
	public GameObject treasure;

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
				Camera.main.GetComponent<LevelManager>().FinishLevel();
			}
			GameObject newPlatform = 
				(GameObject)platformController.SpawnNewPlatform(gameObject.tag=="PlatformForward");
			if (parent_id == PlatformController.platformsPerLevel - 1){ 
				//We spawned the last platform and the treasure must be instantiated
				Vector2 position = newPlatform.transform.position;
				position.y += 2.5f;
				Object newTreasure = 
					Instantiate (treasure, position, Quaternion.identity);
				GameObject gameTreasure = (GameObject)newTreasure;
				gameTreasure.GetComponent<TreasureController>().placeTreasure();
			}
			Destroy (gameObject);
		}
	}
}
