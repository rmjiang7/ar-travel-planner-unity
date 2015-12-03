using UnityEngine;
using System.Collections;

public class ItineraryEntryUpdate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (
				new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			RaycastHit hit;
			Debug.Log (GetComponent<BoxCollider> ().bounds);
			if (Physics.Raycast (ray, out hit)) {
				Debug.Log ("Changed");
				UpdateText ("Changed!");
			}
		}

#if UNITY_ANDROID
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay(
					new Vector3(touch.position.x, touch.position.y, 0));
				RaycastHit hit;

				if(Physics.Raycast(ray, out hit)){
					if (GetComponent<BoxCollider> ().bounds.Contains (touch.position)) {
						UpdateText ("Changed!");
					}
				}
			}
		}
#endif
	}

	void UpdateText(string entry) {
		GetComponent<TextMesh> ().text = entry;
		BoxCollider bc = gameObject.AddComponent<BoxCollider> ();
		bc.isTrigger = true;
		bc.size = GetComponent<TextMesh> ().GetComponent<Renderer> ().bounds.size;
	}
	
	void SetRelativePosition(float x, float y, float z) {
		GetComponent<TextMesh> ().transform.localPosition = new Vector3(x, y, z);
	}

}
