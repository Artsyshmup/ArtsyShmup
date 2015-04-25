using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayIntro : MonoBehaviour {

	public Image imagePanel;
	public Text message;
	public Color showBackgroundPanel;
	public Color hideBackgroundPanel;
	public Color showTextColor;
	public Color hideTextColor;

	private static bool USED = false;
	private float messageDelay = 6f;
	private string[] messages = {
		"Your mission is to recover the lost object located on the last platform of each level.",
		"To go to such platform, you'll need to move right",
		"Jump from platform to platform and stay alive",
		"Along the way multiple enemies will try to harm you. Avoid getting hurt and shoot them",
		"Once you recover the lost object, move left and go back.",
		"But careful, once you're about to finish you'll have to face a boss enemy",
		"To move and jump you can use the arrow keys or the A,W,D keys",
		"To pause the game, use the space bar. To aim use the mouse and to shoot click the left mouse button"
	};
	
	// Update is called once per frame
	void Update () {
		if (!USED) {
			StartCoroutine ("displayMessageCoroutine");
			USED = true;
		}
	}

	private IEnumerator displayMessageCoroutine()
	{
		imagePanel.color = showBackgroundPanel;
		message.color = showTextColor;
		Time.timeScale = 0f;
		for (int idx=0; idx<messages.Length; idx++) {
			message.text = messages [idx];
			float pauseEndTime = Time.realtimeSinceStartup + messageDelay;
			while (Time.realtimeSinceStartup < pauseEndTime)
			{
				yield return 0;
			}
		}
		Time.timeScale = 1;
		message.color = hideTextColor;
		imagePanel.color = hideBackgroundPanel;
	}
}
