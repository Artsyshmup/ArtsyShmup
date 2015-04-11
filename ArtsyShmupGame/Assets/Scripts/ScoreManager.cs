using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	private static int SCORE = 0;
	private static int INITIAL_SCORE = 0;
	private Text scoreText;

	// Use this for initialization
	void Awake () {
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + SCORE;
	}

	public void AddScore(int amount){
		SCORE += amount;
	}

	public void Reset()
	{
		SCORE = INITIAL_SCORE;
	}

	public void CommitScore()
	{
		INITIAL_SCORE = SCORE;
	}
}
