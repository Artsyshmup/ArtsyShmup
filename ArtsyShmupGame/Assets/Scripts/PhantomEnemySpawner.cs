using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
//using System.Random;

public class PhantomEnemySpawner : EnemySpawningController {

	//IDEA:  whenever platform controller creates a new platform it needs to fire an event, then 
	//platform enemy spawner will check if the new platform has a platform.id % spawnPhantomEver ==0
	//and if so create a phantom on the platform
	
	public GameObject phantomEnemyPrefab;
	//public int normalRadius = 3;
	//public int normalXOffset = 15;
	public int lowSpawnBoundary = 3;
	public int highSpawnBoundary = 7;
	public int spawnNextPhantom; //spawn a phantom on every ith platform
	public int platformIdLastPhantom; //platform id of the last platform on which a phantom was spawned

	void Awake()
	{
		spawnNextPhantom = randomInt ();
		//base.setProperties(phantomEnemyPrefab, normalRadius, normalXOffset);
	}
	
	void Update() {

		if ((PlatformController.total_platform_id % spawnNextPhantom == 0) && (PlatformController.total_platform_id != platformIdLastPhantom)) {
			SpawnEnemy(PlatformController.total_platform_id);
			platformIdLastPhantom = PlatformController.total_platform_id;
			spawnNextPhantom = randomInt ();
			Debug.Log ("test");
		}
	}
	
	void SpawnEnemy(int platformId) {
		GameObject platform = GameObject.Find ("Platform" + platformId);
		Vector2 spawnPos = platform.transform.position;
		spawnPos.y += 0.5f; //how to get the height of the platform
		spawnPos.y += (phantomEnemyPrefab.collider2D.bounds.extents.y);
		Instantiate (phantomEnemyPrefab, spawnPos, Quaternion.identity);
	}

	int randomInt() {
		//return a random integer between 3 and 7
		return Random.Range (lowSpawnBoundary, highSpawnBoundary);
	}
}
