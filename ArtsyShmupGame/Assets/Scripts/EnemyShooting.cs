using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {
	public float timeBetweenBullets = 3f;
	public float range = 100f;

	float timer;
	Ray2D shootRay;
	RaycastHit2D shootHit;
	int shootableMask;
	ParticleSystem gunParticles;
	LineRenderer gunLine;
	Light gunLight;
	float effectsDisplayTime = .2f;

	private Vector3 targetPoint;
	
	// Use this for initialization
	void Awake () {
		shootableMask = LayerMask.GetMask ("Player");
		gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent<LineRenderer> ();
		gunLight = GetComponent<Light> ();
	}
	
	/// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeBetweenBullets && Time.timeScale != 0) {
			targetPoint = GameObject.Find("Player").transform.position;
			Shoot();
		}
		if (timer >= timeBetweenBullets * effectsDisplayTime) {
			DisableEffects();
		}
	}
	
	void DisableEffects()
	{
		gunLine.enabled = false;
		gunLight.enabled = false;
	}
	
	void Shoot()
	{
		timer = 0f;
		
		gunLight.enabled = true;
		
		gunParticles.Stop ();
		gunParticles.Play ();
		
		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);
		
		shootRay.origin = transform.position;
		if (targetPoint == null) {
			shootRay.direction = transform.forward;
		} else {
			shootRay.direction = targetPoint - transform.position;
		}
		shootHit = Physics2D.Raycast (shootRay.origin, shootRay.direction, range, shootableMask);
		if (shootHit.collider!=null) {
			PlayerController playerHit = shootHit.collider.GetComponent<PlayerController>();
			if(playerHit!=null){
				playerHit.TakeDamage();
			}
			gunLine.SetPosition (1, shootHit.point);
		} else {
			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
		}
	}
}
