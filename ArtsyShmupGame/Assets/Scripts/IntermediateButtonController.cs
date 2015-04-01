using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntermediateButtonController : MonoBehaviour {
	public void FireClickEvent()
	{
		Application.LoadLevel("SceneLevel1");
	}
}
