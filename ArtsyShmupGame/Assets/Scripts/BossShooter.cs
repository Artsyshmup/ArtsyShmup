using UnityEngine;
using System.Collections;

public class BossShooter : MonoBehaviour {

	public GameObject bullet;
	public float speed;
	private GameObject player;
	public float timeBetweenShooting;
	private float timer = 0f;

	void Awake()
	{
		this.player = GameObject.Find ("Player");
	}

	// Update is called once per frame
	void Update () {
		if (timer >= timeBetweenShooting) {
			GameObject newBullet1 = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
			Bullet bulletScript1 = newBullet1.GetComponent<Bullet> ();
			bulletScript1.MoveTo (true, false); //To the player
			GameObject newBullet2 = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
			Bullet bulletScript2 = newBullet2.GetComponent<Bullet> ();
			bulletScript2.MoveTo (false, true); //To the player
			GameObject newBullet3 = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
			Bullet bulletScript3 = newBullet3.GetComponent<Bullet> ();
			bulletScript3.MoveTo (false, false); //To the player
			timer = 0f;
		} else {
			timer += Time.deltaTime;
		}
	}
}
