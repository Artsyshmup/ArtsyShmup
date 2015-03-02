using UnityEngine;
using System.Collections;

public class EnemySpawningController : MonoBehaviour {
	private Transform player;

	public GameObject enemyPrefab;
	public int numberOfEnemies = 3;
	public float spawnDelay = 3f;
	[HideInInspector]
	public int enemiesAlive = 0;
	private float timer;

	// Use this for initialization
	void Awake () {
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (enemiesAlive < numberOfEnemies && timer>=spawnDelay) { //Spawn enemy
			SpawnEnemy();
		}
	}

	void SpawnEnemy()
	{
		Vector2 spawnPosition = Random.onUnitSphere * 15;
		spawnPosition = spawnPosition + (Vector2)player.position;
		Instantiate (enemyPrefab, spawnPosition, Quaternion.identity);
		enemiesAlive++;
		timer = 0f;
	}
}
