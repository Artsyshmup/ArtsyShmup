using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {
	public float timeBetweenBullets = 3f;
	public GameObject bullet;

	float timer;
	AudioSource enemyShot;
	GameObject player;

	// Use this for initialization
	void Awake () {
		enemyShot = GetComponent<AudioSource> ();
		enemyShot.enabled = true;
		player = GameObject.Find ("Player");
	}
	
	/// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeBetweenBullets && Time.timeScale != 0) {
			enemyShot.Play ();
			Shoot();
		}
		Vector3 difference = player.transform.position - transform.position;
		if(difference.x > 0){
			transform.parent.transform.localScale = new Vector3(-1, 1, 1);
		}else{
			transform.parent.transform.localScale  = new Vector3(1, 1, 1);
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
