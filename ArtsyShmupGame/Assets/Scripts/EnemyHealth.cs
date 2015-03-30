using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int enemeHealth = 3;
	public int enemyValue = 10;

	private EnemySpawningController spawnController;
	private ScoreManager scoreManager;

	void Awake()
	{
		spawnController = GameObject.Find ("Main Camera").GetComponent<EnemySpawningController> ();
		scoreManager = GameObject.Find ("Main Camera").GetComponent<ScoreManager> ();
	}

	public void TakeDamage()
	{
		this.enemeHealth--;
		if (this.enemeHealth == 0) {
			Die ();
		}
	}

	void Die()
	{
		Destroy (gameObject);
		spawnController.enemiesAlive--;
		scoreManager.AddScore (this.enemyValue);
	}
}
