using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {

	public void Move(Vector2 moveTo)
	{
		transform.Translate (moveTo * Time.deltaTime);
	}
}
