using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SelectableLandmark))]
public class AddToItineraryAction : MonoBehaviour {

	public string message;

	private GameObject itinerary;
	private SelectableLandmark parentLandmark;

	private Vector3 startPos;
	private float minSwipeDistY = 400.0f;

	// Use this for initialization
	void Start () {
		itinerary = GameObject.Find ("ItineraryPlane");
		parentLandmark = GetComponent<SelectableLandmark> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (parentLandmark.selected()) {
			if (Input.touchCount != 0) {
				Touch touch = Input.GetTouch (0);
				switch (touch.phase) {
				case TouchPhase.Began:
					startPos = touch.position;
					break;
				case TouchPhase.Ended:
					float swipeDistVertical = 
						(new Vector3 (0, touch.position.y, 0) -
						 new Vector3 (0, startPos.y, 0)).magnitude;
					if (swipeDistVertical > minSwipeDistY) {
						itinerary.SendMessage("Add",message);
					}
					break;
				default:
					break;
				}
			}
		}
	}
}
