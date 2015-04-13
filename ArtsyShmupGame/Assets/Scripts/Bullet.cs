using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	private GameObject player;
	private Vector3 moveTo;
	public float speed;

	void Awake()
	{
		player = GameObject.Find ("Player");
	}

	public void MoveTo(bool toPlayer, bool up)
	{
		if (toPlayer) {
			moveTo = player.transform.position - transform.position;
		} else {
			if(up){
				moveTo = player.transform.position - transform.position;
				moveTo.y += 5;
			} else {
				moveTo = player.transform.position - transform.position;
				moveTo.y -= 5;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		transform.position += moveTo * speed * Time.deltaTime;
	}
}
