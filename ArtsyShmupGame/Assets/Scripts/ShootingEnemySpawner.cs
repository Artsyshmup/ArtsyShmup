using UnityEngine;
using System.Collections;

public class ShootingEnemySpawner : EnemySpawningController {

	public GameObject normalEnemyPrefab;
	public int normalRadius = 1;
	public int shootingXOffset = 2;
	
	void Awake()
	{
		base.setProperties(normalEnemyPrefab, normalRadius, shootingXOffset);
	}
}
