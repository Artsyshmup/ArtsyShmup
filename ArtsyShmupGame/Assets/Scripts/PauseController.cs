using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {
	/// <summary>
	/// Background image semi-transparent that will appear when the player pauses the game.
	/// </summary>
	public Image pausedImage;
	/// <summary>
	/// Text that will appear on the pausedImage background informing the users that they have paused the game
	/// </summary>
	public Text pausedText;
	/// <summary>
	/// Boolean variable that will check if the game is paused or not.
	/// </summary>
	private bool paused = false;
	/// <summary>
	/// Reference to the level manager. We need this reference so we know if the game is over or still playing (we don't 
	/// want to be able to pause the game in the game over screen).
	/// </summary>
	private LevelManager levelManager;

	/// <summary>
	/// Awake this instance. Executed when the script is created and loaded. We get the reference of the level manager
	/// that is a component of the main camera.
	/// </summary>
	void Awake()
	{
		levelManager = Camera.main.GetComponent<LevelManager> ();
	}

	/// <summary>
	/// Update is called once per frame. Update is not affected by a change in timescale since I'm not using time.deltatime.
	/// First, Update will check if the player has pressed the space bar. If such key was pressed, the paused variable will change
	 /// from not paused to paused, or viceversa. Then, the alpha values of the image and text will change accordingly to the status
	/// (paused or not paused). Finally, if paused the timescale will be 0 so the game is completely paused. Otherwise it will be 1
	/// and the game will resume as usual.
	/// </summary>
	void Update () {
		if (Input.GetKeyDown ("space") && !levelManager.gameOver) {
			paused = !paused;
			float imageAlpha = (paused) ? 120 / 255f : 0f;
			float textAlpha = (paused) ? 1f : 0f;
			pausedImage.color = new Color (1f, 1f, 1f, imageAlpha);
			pausedText.color = new Color (50 / 255f, 50 / 255f, 50 / 255f, textAlpha);
			Time.timeScale = (paused) ? 0f : 1f;
		}
	}
}
