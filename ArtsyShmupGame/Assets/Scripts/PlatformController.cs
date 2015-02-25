using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
	public GameObject spawnedElement;
	private static int previous_platform_id = 0;

	private int platform_id;
	private GameObject spawningElement;

	// Use this for initialization
	void Awake () {
		this.platform_id = PlatformController.previous_platform_id + 1;
		PlatformController.previous_platform_id = this.platform_id;
	}

	public void SpawnNewPlatform()
	{
		Vector2 newPosition = transform.position;
		Debug.Log (transform.localScale.x);
		float jumpHeight = GameObject.Find ("Player").GetComponent<PlayerController> ().jumpHeight;
		newPosition.x += transform.localScale.x +  jumpHeight/3;
		newPosition.y += Random.Range (-jumpHeight/2, jumpHeight/4);
		Debug.Log ("New position x: " + newPosition.x);
		Instantiate (spawnedElement, newPosition, Quaternion.identity);
	}
}
