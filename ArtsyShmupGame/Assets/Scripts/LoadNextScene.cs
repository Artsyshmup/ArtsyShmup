using UnityEngine;
using System.Collections;

public class LoadNextScene : MonoBehaviour {
	public string nextSceneName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space"))
			Application.LoadLevel (nextSceneName);
	}
}
