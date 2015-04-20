using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	//how to manage the music so you don't have to load all the tracks at once?
	public LevelManager levelManager;
	private int level;

	public AudioSource Level1Music;
	public AudioSource Level2Music;
	public AudioSource Level3Music;
	public AudioSource Level4Music;
	public AudioSource Level5Music;
	public AudioSource Level6Music;

	// Use this for initialization
	void Start () {
		level = 0;
	}
	
	// Update is called once per frame
	void Update () {
			if (level != levelManager.getLevel()) { //the level has changed
				level = levelManager.getLevel ();
				DisableAudio ();
				switch (level) {
					case 1:
						Level1Music.enabled = true;
						Level1Music.Play ();
						break;
					case 2:
						Level2Music.enabled = true;
						Level2Music.Play ();
						break;
					case 3:
						Level3Music.enabled = true;
						Level3Music.Play ();
						break;
					case 4:
						Level4Music.enabled = true;
						Level4Music.Play ();
						break;
					case 5:
						Level5Music.enabled = true;
						Level5Music.Play ();
						break;
					case 6:
						Level6Music.enabled = true;
						Level6Music.Play ();
						break;
				}
			}
	}

	void DisableAudio() 
		{
				Level1Music.enabled = false;
				Level2Music.enabled = false;
				Level3Music.enabled = false;
				Level4Music.enabled = false;
				Level5Music.enabled = false;
				Level6Music.enabled = false;
		}
}
