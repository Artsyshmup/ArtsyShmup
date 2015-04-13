using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int enemeHealth = 3;
	public int enemyValue = 10;
	public GameObject enemy;
	
	private ScoreManager scoreManager;

	void Awake()
	{
		scoreManager = GameObject.Find ("Main Camera").GetComponent<ScoreManager> ();
	}

	public void TakeDamage()
	{
		this.enemeHealth--;
		if (this.enemeHealth == 0) {
			Die ();
		}
	}

	public void Die()
	{
		EnemySpawningController spawnController = null;
		switch (enemy.tag) {
		case "NormalEnemy": spawnController = Camera.main.GetComponent<NormalEnemySpawner> (); break;
		case "ShootingEnemy": spawnController = Camera.main.GetComponent<ShootingEnemySpawner> (); break;
		}
		Destroy (gameObject);
		if (spawnController != null) {
			spawnController.enemiesAlive--;
		}
		scoreManager.AddScore (this.enemyValue);
	}
}
