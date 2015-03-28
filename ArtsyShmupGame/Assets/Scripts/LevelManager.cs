using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	public static LevelManager instance = null;
	private static int LEVEL = 1;
	[HideInInspector]
	public bool gameOver = false;
	public float messageDelay = 3f;

	public Image levelPassedImage;
	public Text levelPassedText;
	public Image gameOverImage;
	public Text gameOverText;
	public Text replayText;

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if(instance!=this){
			Destroy (gameObject);
		}
		gameOver = false;
	}

	public void FinishLevel()
	{
		PlayerController playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
		if (playerController.GetPickupsSize () > 0) { // The player picked up the treasure
			StartCoroutine("WinLevel");
		} else {
			LoseLevel();
		}
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			Destroy(enemy);
		}
		GameObject.Find ("Player").GetComponent<PlayerController> ().isAlive = false;
	}

	private IEnumerator WinLevel(){
		levelPassedImage.color = new Color (141 / 255f, 151 / 255f, 255 / 255f, 1f);
		levelPassedText.text = "You've passed level " + LevelManager.LEVEL++;
		levelPassedText.color = new Color (0f, 0f, 0f, 1f);
		Time.timeScale = 0f;
		float pauseEndTime = Time.realtimeSinceStartup + messageDelay;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
		}
		Time.timeScale = 1;
		levelPassedImage.color = new Color (141 / 255f, 151 / 255f, 255 / 255f, 0f);
		levelPassedText.text = "You've passed level " + LevelManager.LEVEL;
		levelPassedText.color = new Color (0f, 0f, 0f, 0f);
		PlatformController.total_platform_id = 0;
		Application.LoadLevel(Application.loadedLevel);
	}

	private void LoseLevel(){
		gameOverImage.color = new Color(116/255f, 116/255f, 116/255f, 1);
		gameOverText.text = "You don't have the object";
		gameOverText.fontSize = 30;
		gameOverText.color = new Color (0, 0, 0, 1);
		replayText.color = new Color (0, 0, 0, 1);
		gameOver = true;
	}

	void Update()
	{
		if (gameOver) {
			if (Input.GetKeyDown (KeyCode.R)) {
				PlatformController.total_platform_id = 0;
				Camera.main.GetComponent<ScoreManager>().Reset();
				GameObject.Find("Player").GetComponent<PlayerController>().ResetHealth();
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
