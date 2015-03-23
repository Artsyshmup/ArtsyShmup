using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TreasureController : MonoBehaviour {
	private bool floatingUp = true;
	private float maxUp;
	private float minUp;
	private float deltaUp = 1f;
	private float speed = 1f;

	private float messageDelay = 4f;
	private Image messageBackground;
	private Text messageText;

	void Awake()
	{
		messageBackground = GameObject.Find ("InfoMessage").GetComponent<Image> ();
		messageText = GameObject.Find ("ObjectRecoveredMessage").GetComponent<Text> ();
	}

	public void placeTreasure()
	{
		maxUp = transform.position.y + deltaUp;
		minUp = transform.position.y - deltaUp;
	}

	void Update()
	{
		if (floatingUp) {
			FloatingUp();
		}else {
			FloatingDown();
		}
	}

	private void FloatingUp()
	{
		Vector2 newPosition = new Vector2 (transform.position.x, transform.position.y);
		newPosition.y += speed * Time.deltaTime;
		transform.position = newPosition;
		if (transform.position.y >= maxUp) {
			floatingUp = false;
		}
	}

	private void FloatingDown()
	{
		Vector2 newPosition = new Vector2 (transform.position.x, transform.position.y);
		newPosition.y -= speed * Time.deltaTime;
		transform.position = newPosition;
		if (transform.position.y <= minUp) {
			floatingUp = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			other.gameObject.GetComponent<PlayerController>().AddToPickups(gameObject);
			Destroy(gameObject);
			Camera.main.GetComponent<InfoMessageManager>().displayMessage();
		}
	}
}
