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

	private float skin = .005f;
	RaycastHit2D hit;
	
	void Awake()
	{
		this.playerCollider = GetComponent<BoxCollider2D> ();
		this.size = this.playerCollider.size;
	}

	public void Move(Vector2 moveTo)
	{
		float componentY = moveTo.y;
		float componentX = moveTo.x;

		this.grounded = false;

		for (int i=0; i<3; i++) {
			float direction = Mathf.Sign(componentY);
			float x = (transform.position.x - this.size.x/2) + this.size.x/2 * i;
			float y = transform.position.y + this.size.y/2 * direction;
			Vector2 origin = new Vector2(x, y);
			Vector2 dir = new Vector2(0, direction);
			Debug.DrawRay(origin, dir);
			hit = Physics2D.Raycast(origin, dir, Mathf.Abs(componentY), this.collisionMask);
			if(hit.collider!=null){
				float distance = Vector3.Distance(origin, hit.point);
				if(distance>skin){
					componentY = distance * direction + skin;
				} else {
					if(direction!=1){
						componentY = 0;
					}
				}
				grounded = true;
				break;
			}
		}

		transform.Translate (new Vector2(componentX, componentY));
	}
}
