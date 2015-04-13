using UnityEngine;
using System.Collections;

public abstract class EnemySpawningController : MonoBehaviour {
	private Transform player;

	private GameObject enemyPrefab;
	public int numberOfEnemies = 3;
	public float spawnDelay = 3f;
	[HideInInspector]
	public int enemiesAlive = 0;
	private float timer = 0f;
	private int radius;
	private int xOffset;

	protected void setProperties(GameObject iEnemyPrefab, int iRadius, int xOffset)
	{
		player = GameObject.Find ("Player").transform;
		this.enemyPrefab = iEnemyPrefab;
		this.radius = iRadius;
		this.xOffset = xOffset;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (enemiesAlive < numberOfEnemies && timer >= spawnDelay) { //Spawn enemy
			SpawnEnemy();
		}
	}

	void SpawnEnemy()
	{
		Vector2 spawnPosition = Random.onUnitSphere * radius; 
		spawnPosition = spawnPosition + (Vector2)player.position;
		GameObject[] backwards = GameObject.FindGameObjectsWithTag ("PlatformBackward");
		if (backwards.Length == 0) {
			spawnPosition.x += xOffset;
		} else {
			spawnPosition.x -= xOffset;
		}
		Instantiate (enemyPrefab, spawnPosition, Quaternion.identity);
		enemiesAlive++;
		timer = 0f;
	}
}
