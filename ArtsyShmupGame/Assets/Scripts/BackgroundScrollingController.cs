using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Infinite background scrolling script
public class BackgroundScrollingController : MonoBehaviour
{

	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(-1, 0);
	/// movement should be applied to camera
	public bool isLinkedToCamera = false;
	private List<Transform> backgroundPart; //list of all children with a renderer	
	//get all the children
	void Start() {
		// get all the children of the layer with a renderer
		backgroundPart = new List<Transform>();

		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			// Add only the visible children
			if (child.renderer != null)
			{
				backgroundPart.Add(child);
			}
		}

		// sort by position (ie get left bg first)
		backgroundPart = backgroundPart.OrderBy(
			t => t.position.x
			).ToList();
	}
	
	void Update()
	{
		// movement
		Vector2 movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
		movement *= Time.deltaTime;
		transform.Translate(movement);
		// Move the camera
		if (isLinkedToCamera)
		{
			Camera.main.transform.Translate(movement);
		}

		// list is ordered from left (x position) to right.
		Transform firstChild = backgroundPart.FirstOrDefault();

		if (firstChild != null)
		{
			// check if the child is already (partly) before the camera
			if (firstChild.position.x < Camera.main.transform.position.x)
			{
				if (firstChild.renderer.IsVisibleFrom(Camera.main) == false)
				{
					// get the last child position
					Transform lastChild = backgroundPart.LastOrDefault();
					Vector3 lastPosition = lastChild.transform.position;
					Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);
					firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);
					//move recycled child to last position of list
					backgroundPart.Remove(firstChild);
					backgroundPart.Add(firstChild);
				}
			}
		}
	}
}
