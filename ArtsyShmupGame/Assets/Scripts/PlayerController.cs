using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	// Public variable to control the speed of the player
	public float gravity = 20;
	public float speed = 4;
	public float initialSpeed = 4;
	public float maxSpeed = 10;
	public float jumpHeight = 70;
	public int health = 3;
	public Text healthText;
	public Image damageImage;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	private bool damaged = false;
	private float camRayLength = 100f;
	public float flashSpeed = 5f;

	private PlayerPhysics playerPhysics;
	private PlayerShooting shooting;
	private Vector2 moveTo;
	public bool isAlive = true;
	private Image gameOverImage;
	private Text gameOverText;

	// This function will be executed when it's loaded.
	void Awake () {
		this.playerPhysics = GetComponent<PlayerPhysics> ();
		healthText.text = "" + health;
		shooting = GameObject.Find ("ShootingEnd").GetComponent<PlayerShooting> ();
		gameOverImage = GameObject.Find ("GameOverImage").GetComponent<Image>();
		gameOverText = GameObject.Find ("GameOverText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive) {
			float horizontal = Input.GetAxisRaw("Horizontal");
			if(horizontal!=0){ //User is pressing a key to move the player. Acceleration
				if(speed<maxSpeed){
					speed += (rigidbody2D.mass * speed) * Time.deltaTime;
				} else {
					speed = maxSpeed;
				}
			} else {
				speed = initialSpeed;
			}
			moveTo.x = horizontal * speed;
			
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
				moveTo.y = 0;
				float vertical = Input.GetAxisRaw("Vertical");
				if(vertical>0){
					moveTo.y = jumpHeight;
				}
			}
			moveTo.y -= this.gravity * Time.deltaTime; //We add the effects of gravity
			playerPhysics.Move (moveTo * Time.deltaTime);
			
			Turning ();
		}
	}

	public void TakeDamage()
	{
		Debug.Log ("Player was damaged");
		if (isAlive) {
			this.health--;
			healthText.text = "" + health;
			this.damaged = true;
			if (this.health == 0) { //Game Over
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

		gameOverImage.color = new Color(116/255f, 116/255f, 116/255f, 1);
		gameOverText.color = new Color (0, 0, 0, 1);
		Camera.main.GetComponent<LevelManager>().gameOver = true;
	}
}
