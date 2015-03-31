using UnityEngine;
using System.Collections;

public class ShootingEnemySpawner : EnemySpawningController {

	public GameObject normalEnemyPrefab;
	public int normalRadius = 6;
	
	void Awake()
	{
		base.setProperties(normalEnemyPrefab, normalRadius);
	}
}
