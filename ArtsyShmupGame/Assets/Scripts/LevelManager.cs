using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public static LevelManager instance = null;
	private int level = 1;
	[HideInInspector]
	public bool gameOver = false;

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if(instance!=this){
			Destroy (gameObject);
		}
		gameOver = false;
	}

	public void winLevel()
	{

	}

	void Update()
	{
		if (gameOver) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
