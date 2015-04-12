using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

public class PhantomEnemySpawner : EnemySpawningController {

	//IDEA:  whenever platform controller creates a new platform it needs to fire an event, then 
	//platform enemy spawner will check if the new platform has a platform.id % spawnPhantomEver ==0
	//and if so create a phantom on the platform
	
	public GameObject phantomEnemyPrefab;
	private List<GameObject> platforms;
	public int normalRadius = 3;
	public int normalXOffset = 15;
	public int spawnPhantomEvery = 5; //spawn a phantom on every ith platform
	
	void Awake()
	{
		GameObject.Find
		GameObject.Find ("Platform");
		base.setProperties(phantomEnemyPrefab, normalRadius, normalXOffset);
	}
	
	void Update() {
		if (enemiesAlive < numberOfEnemies && timer >= spawnDelay) { //Spawn enemy
			SpawnEnemy();
		}
	}
	
	void SpawnEnemy() {
		
	}
}
