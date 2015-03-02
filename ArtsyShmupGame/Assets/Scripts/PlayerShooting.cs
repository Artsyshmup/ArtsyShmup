using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	public float timeBetweenBullets = 0.15f;
	public float range = 100f;

	float timer;
	Ray2D shootRay;
	RaycastHit2D shootHit;
	int shootableMask;
	ParticleSystem gunParticles;
	LineRenderer gunLine;
	Light gunLight;
	float effectsDisplayTime = .2f;

	public Vector3 targetPoint;

	// Use this for initialization
	void Awake () {
		shootableMask = LayerMask.GetMask ("Enemy");
		gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent<LineRenderer> ();
		gunLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0) {
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
			EnemyController enemyHit = shootHit.collider.GetComponent<EnemyController>();
			if(enemyHit!=null){
				enemyHit.TakeDamage();
			}
			gunLine.SetPosition (1, shootHit.point);
		} else {
			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
		}
	}
}
