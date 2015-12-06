// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.
// Credit to https://gist.github.com/JISyed/5017805

using UnityEngine;
using System.Collections;

public class CameraActions : MonoBehaviour 
{

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
			Ray ray = Camera.main.ScreenPointToRay (
				new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			RaycastHit[] hits;
			hits = Physics.RaycastAll( ray.origin, ray.direction, Mathf.Infinity);

			for ( int i = 0; i < hits.Length; i++) {
				RaycastHit hit = hits[i];
				if(hit.collider.gameObject.GetComponent<SelectableLandmark>())
				{
					hit.collider.gameObject.SendMessage("ToggleSelect");
				}
			}
		}

		/*
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

				Ray ray = Camera.main.ScreenPointToRay (
					new Vector3 (touch.position.x, touch.position.y, 0));
				RaycastHit hit;
				
				if(Physics.Raycast (ray, out hit, Mathf.Infinity))
				{
					hit.collider.gameObject.SendMessage("OnRayHit");
				}
				break;
			case TouchPhase.Ended:
				float swipeDistVertical = 
					(new Vector3(0, touch.position.y,0) -
					 new Vector3(0, startPos.y, 0)).magnitude;
				if(swipeDistVertical > minSwipeDistY)
				{
					//itinerary.SendMessage("Add","This is a touch event.");
				}
				break;
			default:
				break;
			}
		}
#endif
		*/
	}

}