using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;

public class IntermediateButtonController : MonoBehaviour {
	private StreamReader reader;
	private static string FILE_PATH = "Assets/Scripts/TextFiles/DIALOG_";
	private static int NEXT_LEVEL = 2;
	private Color panelColor = new Color(1f, 1f, 1f, 202/255f);
	private Color textColor = new Color(0f, 0f, 0f, 1f);

	public Image playerPanel;
	public Text playerText;
	public Image bossPanel;
	public Text bossText;

	/// <summary>
	/// This function will be called when the script is loaded. It will create and open the stream reader
	/// to read the dialog
	/// </summary>
	void Awake()
	{
		reader = new StreamReader(FILE_PATH + NEXT_LEVEL + ".txt");
		NEXT_LEVEL++;
		FireClickEvent ();
	}

	/// <summary>
	/// This function will be called when the button NEXT is clicked. It will read the next line of the dialog text file and display such line on the screen.
	/// If there are no more lines, the new level will be loaded.
	/// </summary>
	public void FireClickEvent()
	{
		if (!reader.EndOfStream) { //Still more dialog to display
			string rawLine = reader.ReadLine();
			string[] parts = rawLine.Split(new Char[]{':'});
			displayDialog(parts[0], parts[1]);
		} else { // No more dialog, so we load the next level
			reader.Close();
			Application.LoadLevel("SceneLevel1");
		}
	}

	/// <summary>
	/// This function will make the corresponding panel and text visible, and hide the other panel and text.
	/// </summary>
	/// <param name="character">The character talking now.</param>
	/// <param name="dialog">Its dialog.</param>
	private void displayDialog(string character, string dialog)
	{
		Image currentPanel = (character == "player") ? playerPanel : bossPanel;
		Image otherPanel = (character == "player") ? bossPanel : playerPanel;
		Text currentText = (character == "player") ? playerText : bossText;
		Text otherText = (character == "player") ? bossText : playerText;

		otherText.color = new Color (0f, 0f, 0f, 0f);
		otherPanel.color = new Color (0f, 0f, 0f, 0f);
		currentPanel.color = panelColor;
		currentText.color = textColor;
		currentText.text = dialog;
	}
}
