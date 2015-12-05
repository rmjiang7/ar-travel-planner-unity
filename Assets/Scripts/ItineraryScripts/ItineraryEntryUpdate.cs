using UnityEngine;
using System.Collections;

public class ItineraryEntryUpdate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

#if UNITY_ANDROID
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay (
					new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
				RaycastHit hit;
				
				BoxCollider bc = (BoxCollider) gameObject.GetComponent<BoxCollider>();
				if (bc.Raycast (ray, out hit, Mathf.Infinity)) {
					UpdateText ("Changed!");
				}
			}
		}
#endif
	}

	// Update the text on the itinerary entry
	void UpdateText(string entry) {
		if (transform.Find ("ItineraryEntryColumnName") != null) {
			GameObject childName = transform.Find ("ItineraryEntryColumnName").gameObject;
			childName.SendMessage ("UpdateText", entry);
			childName.GetComponent<TextMeshRayHitBoxCollider>().SendMessage("UpdateBoxCollider");
		}
	}

	void UpdateDate(string entry) {
		if (transform.Find ("ItineraryEntryColumnDate") != null) {
			GameObject childDate = transform.Find ("ItineraryEntryColumnDate").gameObject;
			childDate.SendMessage ("UpdateText", entry);
			childDate.GetComponent<TextMeshRayHitBoxCollider>().SendMessage("UpdateBoxCollider");
		}
	}

	void SetRelativePosition(float x, float y, float z) {
		GetComponent<TextMesh> ().transform.localPosition = new Vector3(x, y, z);
	}

}
