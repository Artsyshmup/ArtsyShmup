using UnityEngine;
using System.Collections;

public class TriggerPlatformCollider : MonoBehaviour {
	public GameObject treasure;
	public GameObject portal;
	public GameObject boss;

	private PlatformController platformController;
	private BoxCollider2D collider;
	private int parent_id;
	private bool spawned = false;
	private float jumpHeight;

	void Start()
	{
		jumpHeight = Random.Range (5, 15);
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
		transform.parent.gameObject.GetComponentInChildren<PreviousJumpManager> ().setPosition (gameObject.tag);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			GameObject.Find ("Player").GetComponent<PlayerController>().jumpHeight = jumpHeight;
			if(!spawned){
				spawned = true;
				if(parent_id == PlatformController.platformsPerLevel){ //Time to go back
					for(int i=PlatformController.oldest_platform_id; i<parent_id; i++){
						platformController.DestroyOldPlatform(i);
					}
				}
				GameObject newPlatform = 
					(GameObject)platformController.SpawnNewPlatform(gameObject.tag=="PlatformForward", jumpHeight);
				if (parent_id == 2*PlatformController.platformsPerLevel-1){
					Destroy(newPlatform.transform.Find("PlatformSpawningElement").gameObject.GetComponent<TriggerPlatformCollider>());
				}
				if (parent_id == PlatformController.platformsPerLevel - 1){ 
					//We spawned the last platform and the treasure must be instantiated
					Vector2 position = newPlatform.transform.position;
					position.y += 2f;
					position.x += 1.5f;
					Object newTreasure = 
						Instantiate (treasure, position, Quaternion.identity);
					GameObject gameTreasure = (GameObject)newTreasure;
					gameTreasure.GetComponent<TreasureController>().placeTreasure();
				}
				else if (parent_id == 2*PlatformController.platformsPerLevel - 2){ //We need to instantiate the boss
					Vector3 position = newPlatform.transform.position;
					position.y += 1.25f;
					Instantiate (boss, position, Quaternion.identity);
				}
				else if (parent_id == 2*PlatformController.platformsPerLevel - 1){ 
					//We spawned the last platform and the portal or cave to finish the level must be instantiated
					Vector3 position = newPlatform.transform.position;
					position.y += 2f;
					position.z = 1f;
					Instantiate (portal, position, Quaternion.identity);
				}
			}
		}
	}
}
