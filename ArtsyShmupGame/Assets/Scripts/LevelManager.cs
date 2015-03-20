using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	public static LevelManager instance = null;
	private int level = 1;
	[HideInInspector]
	public bool gameOver = false;

	public Image levelPassedImage;
	public Text levelPassedText;

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
		levelPassedImage.color = new Color (141 / 255f, 151 / 255f, 255 / 255f, 1f);
		levelPassedText.color = new Color (0f, 0f, 0f, 1f);
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			Destroy(enemy);
		}
		GameObject.Find ("Player").GetComponent<PlayerController> ().isAlive = false;
	}

	void Update()
	{
		if (gameOver) {
			if (Input.GetKeyDown (KeyCode.R)) {
				PlatformController.total_platform_id = 0;
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
