// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.
// Credit to https://gist.github.com/JISyed/5017805

using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour 
{
	//
	// VARIABLES
	//
	
	public float turnSpeed = 4.0f;		// Speed of camera turning when mouse moves in along an axis
	public float panSpeed = 4.0f;		// Speed of the camera when being panned
	public float zoomSpeed = 4.0f;		// Speed of the camera going back and forth
	
	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isPanning;		// Is the camera being panned?
	private bool isRotating;	// Is the camera being rotated?
	private bool isZooming;		// Is the camera zooming?

	private GameObject itinerary;

#if UNITY_ANDROID
	private float minSwipeDistY = 10.0f;
	private float minSwipeDistX;
	private Vector2 startPos;
	private ScreenOrientation currentOrientation;
#endif

	
	void Start()
	{
		itinerary = GameObject.Find ("ItineraryPlane");
#if UNITY_ANDROID
		minSwipeDistY = (float) (Screen.height / 10.0);
		currentOrientation = Screen.orientation;
#endif
	}
	
	//
	// UPDATE
	//
	void Update () 
	{
		// Get the left mouse button
		if(Input.GetMouseButtonDown(0))
		{
			Debug.Log("Clicked");
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isRotating = true;
			itinerary.SendMessage("Add","This is a touch event.");
		}
		
		// Get the right mouse button
		if(Input.GetMouseButtonDown(1))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isPanning = true;

			Ray ray = Camera.main.ScreenPointToRay (
				new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			RaycastHit hit;
			
			if(Physics.Raycast (ray, out hit, Mathf.Infinity))
			{
				hit.collider.gameObject.SendMessage("OnRayHit");
			}
		}
		
		// Get the middle mouse button
		if(Input.GetMouseButtonDown(2))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isZooming = true;
		}

#if UNITY_ANDROID

		if (Screen.orientation != currentOrientation)
		{
			currentOrientation = Screen.orientation;
			minSwipeDistY = (float) (Screen.height / 10.0);
		}

		if (Input.touchCount != 0) {

			Touch touch = Input.GetTouch(0);

			switch(touch.phase)
			{
			case TouchPhase.Began:
				itinerary.SendMessage("Add","This is a touch event.");
				break;
			case TouchPhase.Ended:
				float swipeDistVertical = 
					(new Vector3(0, touch.position.y,0) -
					 new Vector3(0, startPos.y, 0)).magnitude;
				if(swipeDistVertical > minSwipeDistY)
				{
					itinerary.SendMessage("Add","This is a touch event.");
				}
				break;
			default:
				break;
			}
		}
#endif
		
		// Disable movements on button release
		if (!Input.GetMouseButton(0)) isRotating=false;
		if (!Input.GetMouseButton(1)) isPanning=false;
		if (!Input.GetMouseButton(2)) isZooming=false;
		
		// Rotate camera along X and Y axis
		if (isRotating)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			
			transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
			transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
		}
		
		// Move the camera on it's XY plane
		if (isPanning)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			
			Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
			transform.Translate(move, Space.Self);
		}
		
		// Move the camera linearly along Z axis
		if (isZooming)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			
			Vector3 move = pos.y * zoomSpeed * transform.forward; 
			transform.Translate(move, Space.World);
		}
	}

}