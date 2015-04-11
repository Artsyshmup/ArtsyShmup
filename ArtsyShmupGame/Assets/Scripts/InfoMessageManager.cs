using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoMessageManager : MonoBehaviour {
	private float messageDelay = 3.5f;

	public void displayMessage()
	{
		StartCoroutine ("displayMessageCoroutine");
	}

	public IEnumerator displayMessageCoroutine()
	{
		Image messageBackground = GameObject.Find ("InfoMessage").GetComponent<Image> ();
		Text messageText = GameObject.Find ("ObjectRecoveredMessage").GetComponent<Text> ();
		messageBackground.color = new Color (1f, 1f, 1f, 125 / 255f);
		messageText.color = new Color (0f, 0f, 0f, 1f);
		Time.timeScale = 0f;
		float pauseEndTime = Time.realtimeSinceStartup + messageDelay;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
		}
		Time.timeScale = 1;
		messageBackground.color = new Color (1f, 1f, 1f, 0f);
		messageText.color = new Color (0f, 0f, 0f, 0f);
	}
}
