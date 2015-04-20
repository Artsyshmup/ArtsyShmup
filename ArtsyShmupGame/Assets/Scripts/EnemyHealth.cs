using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int enemeHealth = 3;
	public int enemyValue = 10;
	public GameObject enemy;
	
	private ScoreManager scoreManager;
	public AudioSource enemyDeathSound;

	void Awake()
	{
		scoreManager = GameObject.Find ("Main Camera").GetComponent<ScoreManager> ();
		enemyDeathSound.enabled = true;
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
		Debug.Log ("sound should be playing");
		enemyDeathSound.Play ();
		enemyDeathSound.Play ();
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
