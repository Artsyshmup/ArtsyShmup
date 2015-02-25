using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
	public GameObject spawnedElement;
	public int destroyDelay = 3;
	private static int previous_platform_id = 0;

	private int platform_id;
	private GameObject spawningElement;

	// Use this for initialization
	void Awake () {
		this.platform_id = PlatformController.previous_platform_id + 1;
		PlatformController.previous_platform_id = this.platform_id;

		gameObject.name = "Platform" + this.platform_id;

		if (this.platform_id >= 6) {
			StartCoroutine("DestroyOldPlatform");
		}
	}

	IEnumerator DestroyOldPlatform()
	{
		Debug.Log("DESTROY OLD PLATFORM");
		GameObject oldPlatform = GameObject.Find("Platform" + (this.platform_id-5));
		oldPlatform.rigidbody2D.isKinematic = false;
		yield return new WaitForSeconds(destroyDelay);
		Destroy (oldPlatform);
	}

	public void SpawnNewPlatform()
	{
		Vector2 newPosition = transform.position;
		float jumpHeight = GameObject.Find ("Player").GetComponent<PlayerController> ().jumpHeight;
		newPosition.x += transform.localScale.x +  jumpHeight/3;
		newPosition.y += Random.Range (-jumpHeight/2, jumpHeight/4);
		Instantiate (spawnedElement, newPosition, Quaternion.identity);
	}
}
