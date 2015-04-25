using UnityEngine;
using System.Collections;

public class CheatingSystem : MonoBehaviour {
	public int available;
	private int left;

	/// <summary>
	/// The number of times the player can still use the cheating system is initially the number
	/// set in the Unity inspector
	/// </summary>
	void Awake()
	{
		this.left = available;
	}

	/// <summary>
	/// If the user presses the key P and has still the option of using the cheating system (left is greater than 0),
	/// then all the enemies will be destroyed.
	/// </summary>
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.P) && left > 0) {
			DestroyEnemies(GameObject.FindGameObjectsWithTag("NormalEnemy"));
			DestroyEnemies(GameObject.FindGameObjectsWithTag("ShootingEnemy"));
			DestroyEnemies(GameObject.FindGameObjectsWithTag("PhantomEnemy"));
			DestroyEnemies(GameObject.FindGameObjectsWithTag("Boss"));
			left--;
		}
	}

	/// <summary>
	/// Destroies the enemies in the array passed as a parameter.
	/// </summary>
	/// <param name="enemies">Enemies.</param>
	private void DestroyEnemies(GameObject[] enemies)
	{
		foreach (GameObject gameObject in enemies){
			EnemyHealth health = gameObject.GetComponent<EnemyHealth>();
			health.Die();
		}
	}
}
