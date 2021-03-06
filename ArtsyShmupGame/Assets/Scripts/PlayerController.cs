﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	// Public variable to control the speed of the player
	public float gravity = 20;
	public float speed = 4;
	public float initialSpeed = 4;
	public float maxSpeed = 10;
	public float jumpHeight = 70;
	private static int INITIAL_HEALTH = 3;
	public static int HEALTH = 3;
	public Text healthText;
	public Image damageImage;
	public Color flashColour = new Color(1f, 0f, 0f, 1f);
	private bool damaged = false;
	private float camRayLength = 100f;
	public float flashSpeed = 5f;

	private PlayerPhysics playerPhysics;
	private PlayerShooting shooting;
	private Vector2 moveTo;
	public bool isAlive = true;
	private Image gameOverImage;
	private Text gameOverText;
	private Text replayText;
	public AudioSource playerDeathSound;
	public AudioSource playerDamageSound;
	public AudioSource playerJumpSound;

	public Animator animator;
	private bool isFacingRight = true;

	[HideInInspector]
	public List<GameObject> pickups = new List<GameObject>();
	
	public void AddToPickups(GameObject gObject){
		if (gObject == null) {
			throw new MissingComponentException("Game object to add to the pickups list not specified");
		}
		pickups.Add (gObject);
	}
	
	public int GetPickupsSize(){
		return pickups.Count;
	}

	// This function will be executed when it's loaded.
	void Awake () {
		this.playerPhysics = GetComponent<PlayerPhysics> ();
		healthText.text = "" + HEALTH;
		shooting = GameObject.Find ("ShootingEnd").GetComponent<PlayerShooting> ();
		gameOverImage = GameObject.Find ("GameOverImage").GetComponent<Image>();
		gameOverText = GameObject.Find ("GameOverText").GetComponent<Text>();
		replayText = GameObject.Find ("ReplayText").GetComponent<Text> ();
		playerDeathSound.enabled = true;
		playerDamageSound.enabled = true;
		playerJumpSound.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive) {
			float horizontal = Input.GetAxisRaw("Horizontal");
			if(horizontal==0){
				horizontal = (Input.GetKeyDown(KeyCode.D)) ? 1 : (Input.GetKeyDown(KeyCode.A)) ? -1 : 0;
			}
			if(horizontal!=0){ //User is pressing a key to move the player. Acceleration
				animator.SetBool("isMoving", true);
				if(speed<maxSpeed){
					speed += (rigidbody2D.mass * speed) * Time.deltaTime;
				} else {
					speed = maxSpeed;
				}
			} else {
				animator.SetBool("isMoving", false);
				speed = initialSpeed;
			}
			moveTo.x = horizontal * speed;

			if(horizontal >= 0){
				transform.localScale = new Vector3(1, 1, 1);
			}else{
				transform.localScale = new Vector3(-1, 1, 1);
			}
			
			if(damaged)
			{
				damageImage.color = flashColour;
			}
			else
			{
				damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
			}
			damaged = false;
			
			if(playerPhysics.grounded){ //We'll jump
				animator.SetBool("isGrounded", true);
				moveTo.y = 0;
				float vertical = Input.GetAxisRaw("Vertical");
				if(vertical==0){
					vertical = (Input.GetKeyDown (KeyCode.W)) ? 1 : 0;
				}
				if(vertical>0){
					playerJumpSound.Play ();
					moveTo.y = jumpHeight;
					animator.SetBool("isGrounded", false);
				}
			}
			moveTo.y -= this.gravity * Time.deltaTime; //We add the effects of gravity
			playerPhysics.Move (moveTo * Time.deltaTime);
			
			Turning ();
		}
	}

	public void TakeDamage()
	{
		if (isAlive) {
			HEALTH--;
			healthText.text = "" + HEALTH;
			this.damaged = true;
			playerDamageSound.Play ();
			if (HEALTH == 0) { //Game Over
				Die ();
			}
		}
	}

	void Turning()
	{
		//This will get the position of the mouse
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//We check that there was a hit
		if (Physics.Raycast (camRay, out hit, camRayLength)) {
			Vector2 point = hit.point;
			shooting.targetPoint = point;
		}
	}

	public void Die()
	{
		shooting.enabled = false;
		isAlive = false;
		playerDeathSound.Play ();

		gameOverImage.color = new Color(116/255f, 116/255f, 116/255f, 1);
		gameOverText.color = new Color (0, 0, 0, 1);
		replayText.color = new Color (0, 0, 0, 1);
		Camera.main.GetComponent<LevelManager>().gameOver = true;
	}

	public void ResetHealth()
	{
		HEALTH = INITIAL_HEALTH;
	}

	public void increaseInitialHealth()
	{
		INITIAL_HEALTH++;
		HEALTH++;
		healthText.text = "" + HEALTH;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet") {
			TakeDamage();
			Destroy(other.gameObject);
		}
	}
}
