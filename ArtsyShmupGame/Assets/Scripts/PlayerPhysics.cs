using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerPhysics : MonoBehaviour {
	// We use a layerMask to define which objects we want to collide
	public LayerMask collisionMask;

	[HideInInspector]
	public bool grounded;

	private BoxCollider2D playerCollider;
	private Vector3 size;
	private Vector3 center;
	
	void Awake()
	{
		this.playerCollider = GetComponent<BoxCollider2D> ();
		this.size = this.playerCollider.size;
		this.center = this.playerCollider.center;
	}

	public void Move(Vector2 moveTo)
	{
		RaycastHit2D hit;
		
		float x = transform.position.x + this.center.x;
		float y = transform.position.y + this.center.y - this.size.y/2;
		this.grounded = false;
		// We create the ray to be used for the raycast: at the left, middle and finally right of the player object
		Vector2 origin = new Vector2 (x, y);
		hit = Physics2D.Raycast (origin, new Vector2 (0, -1), 1, collisionMask);
		if (hit!=null) {
			float distance = Vector2.Distance(origin, hit.point);
			if(distance<0.1){
				grounded = true;
			}
		}
		transform.Translate (moveTo);
	}
}
