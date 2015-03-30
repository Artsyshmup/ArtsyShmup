using UnityEngine;
using System.Collections;

public class NormalEnemySpawner : EnemySpawningController {
	public GameObject normalEnemyPrefab;
	public int normalRadius = 15;

	void Awake()
	{
		base.setProperties(normalEnemyPrefab, normalRadius);
	}
}
