using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SelectableLandmark))]
public class LandmarkActions : MonoBehaviour {

	private Vector3 startPos;
	private float startTime;
	private long maxDuration = 500;
	private float minSwipDistX = 10.0f;
	private float decelleration = -0.05f;
	private float rotationVel = 0.0f;
	private float rotationDeg = 2.0f;

	private SelectableLandmark parentLandmark;

	void Start () {
		parentLandmark = GetComponent<SelectableLandmark> ();
	}

	void Update () {

		if (parentLandmark.selected ()) {
			if (Input.touchCount != 0) {
				Touch touch = Input.GetTouch (0);
				switch (touch.phase) {
				case TouchPhase.Began:
					startPos = touch.position;
					startTime = Time.time * 1000;
					break;
				case TouchPhase.Ended:
					float timeDiff = Time.time * 1000 - startTime;
					if (timeDiff < maxDuration) {
						float swipeDistHorizontal = 
							(new Vector3 (touch.position.x, 0, 0) -
							new Vector3 (startPos.x, 0, 0)).magnitude;
						if (swipeDistHorizontal > minSwipDistX) {
							float velocity = (startPos.x - touch.position.x) / timeDiff;
							rotationVel = velocity;
						}
					}

					break;
				default:
					break;
				}
			}

			DoRotation ();
		}

	}

	void DoRotation() {
		if(rotationVel != 0.0f) {
			float initialSign = Mathf.Sign(rotationVel);
			transform.Rotate(new Vector3(0,rotationDeg * rotationVel,0));
			rotationVel -= decelleration;
			if(Mathf.Sign(rotationVel) != initialSign){
				rotationVel = 0.0f;
			}
		}
	}

}
