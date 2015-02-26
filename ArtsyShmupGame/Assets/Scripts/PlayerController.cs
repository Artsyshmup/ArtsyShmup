using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	// Public variable to control the speed of the player
	public float gravity = 20;
	public float speed = 4;
	public float jumpHeight = 70;
	public int health = 3;
	public Text healthText;

	private PlayerPhysics playerPhysics;
	private Vector2 moveTo;

	// This function will be executed when it's loaded.
	void Awake () {
		this.playerPhysics = GetComponent<PlayerPhysics> ();
		healthText.text = "" + health;
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxisRaw("Horizontal");

		moveTo.x = horizontal * speed;

		if(playerPhysics.grounded){ //We'll jump
			moveTo.y = 0;
			float vertical = Input.GetAxisRaw("Vertical");
			if(vertical>0){
				moveTo.y = jumpHeight;
			}
		}
		moveTo.y -= this.gravity * Time.deltaTime; //We add the effects of gravity
		playerPhysics.Move (moveTo * Time.deltaTime);
	}

	public void TakeDamage()
	{
		this.health--;
		healthText.text = "" + health;
		if (this.health == 0) { //Game Over

		}
	}
}
