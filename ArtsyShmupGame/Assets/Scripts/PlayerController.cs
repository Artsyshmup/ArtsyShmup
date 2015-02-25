using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	// Public variable to control the speed of the player
	public float speed = 4;

	private PlayerPhysics playerPhysics;

	// This function will be executed when it's loaded.
	void Awake () {
		this.playerPhysics = GetComponent<PlayerPhysics> ();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxisRaw("Horizontal");
		Vector2 moveTo = new Vector2 (horizontal, 0) * speed;

		playerPhysics.Move (moveTo);
	}
}
