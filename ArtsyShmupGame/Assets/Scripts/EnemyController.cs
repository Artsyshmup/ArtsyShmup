using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float speed = 3;
	public float attackDelay = .5f;

	private Transform player;
	private bool canAttack = false;
	private PlayerController playerController;
	private float timer = 0;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerController = player.gameObject.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (Vector3.Distance (transform.position, player.transform.position)>1) {
			Vector3 moveTo = player.position - transform.position;
			transform.position += moveTo * speed * Time.deltaTime;
		}

		if (timer>=attackDelay && canAttack) {
			playerController.TakeDamage();
			timer = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			canAttack = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			canAttack = false;
		}
	}
}
