using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {
	public float timeBetweenBullets = 3f;
	public GameObject bullet;

	float timer;
	AudioSource enemyShot;

	// Use this for initialization
	void Awake () {
		enemyShot = GetComponent<AudioSource> ();
		enemyShot.enabled = true;
	}
	
	/// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeBetweenBullets && Time.timeScale != 0) {
			enemyShot.Play ();
			Shoot();
		}
	}
	
	void Shoot()
	{
		timer = 0f;
		GameObject bulletShot = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
		Bullet bScript = bulletShot.GetComponent<Bullet> ();
		bScript.MoveTo (true, false);
	}
}
