using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
	public GameObject spawnedElement;
	public GameObject oldTrigger;
	public int destroyDelay = 3;
	
	[HideInInspector]
	public int platform_id;
	public static int platformsPerLevel = 20;
	[HideInInspector]
	public static int total_platform_id = 0;
	public static int oldest_platform_id = 1;

	// Use this for initialization
	void Awake () {
		this.platform_id = PlatformController.total_platform_id + 1;
		PlatformController.total_platform_id = this.platform_id;

		gameObject.name = "Platform" + this.platform_id;

		if (this.platform_id>5 && 
		    !(this.platform_id > PlatformController.platformsPerLevel && this.platform_id < PlatformController.platformsPerLevel + 6)) {
			DestroyOldPlatform(this.platform_id - 5);
		}
	}

	public void DestroyOldPlatform(int platformID)
	{
		GameObject oldPlatform = GameObject.Find("Platform" + platformID);
		Destroy (oldPlatform);
		PlatformController.oldest_platform_id = platformID + 1;
	}

	public Object SpawnNewPlatform(bool forward, float oldJumpHeight)
	{
		Vector2 newPosition = transform.position;
		float jumpHeight = GameObject.Find ("Player").GetComponent<PlayerController> ().jumpHeight;
		if (forward) {
			newPosition.x += transform.localScale.x + jumpHeight / 3;
		} else {
			newPosition.x -= (transform.localScale.x +  jumpHeight/3);
		}
		newPosition.y += Random.Range (-jumpHeight/5, jumpHeight/5);
		GameObject newPlatform = Instantiate (spawnedElement, newPosition, Quaternion.identity) as GameObject;
		newPlatform.GetComponentInChildren<PreviousJumpManager> ().setJump (oldJumpHeight);
		return newPlatform;
	}
}
