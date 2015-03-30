using UnityEngine;
using System.Collections;

public class PreviousJumpManager : MonoBehaviour {
	private BoxCollider2D collider;
	private float jumpHeight;
	
	void Start()
	{
		collider = GetComponent<BoxCollider2D> ();
	}

	public void setPosition(string typeForward)
	{
		if (typeForward == "PlatformForward") {
			transform.position = new Vector2 (
				transform.parent.position.x - 3,
				transform.parent.position.y + 6);
		} else {
			transform.position = new Vector2 (
				transform.parent.position.x + 3,
				transform.parent.position.y + 6);
		}
	}

	public void setJump(float jump)
	{
		this.jumpHeight = jump;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			GameObject.Find ("Player").GetComponent<PlayerController>().jumpHeight = jumpHeight;
			Debug.Log(GameObject.Find ("Player").GetComponent<PlayerController>().jumpHeight);
		}
	}
}
