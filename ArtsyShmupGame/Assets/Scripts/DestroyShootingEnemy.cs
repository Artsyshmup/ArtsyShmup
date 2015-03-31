using UnityEngine;
using System.Collections;

public class DestroyShootingEnemy : MonoBehaviour {
	private Transform playerTransform;

	void Awake()
	{
		playerTransform = GameObject.Find ("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (playerTransform.position.x - transform.position.x) > 10
			|| Mathf.Abs (playerTransform.position.y - transform.position.y) > 7.5) {
			GetComponent<EnemyHealth>().Die();
		}
	}
}
