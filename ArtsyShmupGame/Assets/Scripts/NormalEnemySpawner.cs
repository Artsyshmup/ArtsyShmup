using UnityEngine;
using System.Collections;

public class NormalEnemySpawner : EnemySpawningController {
	public GameObject normalEnemyPrefab;
	public int normalRadius = 3;
	public int normalXOffset = 15;

	void Awake()
	{
		base.setProperties(normalEnemyPrefab, normalRadius, normalXOffset);
	}
}
