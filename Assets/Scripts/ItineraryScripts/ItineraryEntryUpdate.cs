using UnityEngine;
using System.Collections;

public class ItineraryEntryUpdate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	// Update the text on the itinerary entry
	void UpdateName(string entry) {
		if (transform.Find ("ItineraryEntryColumnName") != null) {
			GameObject childName = transform.Find ("ItineraryEntryColumnName").gameObject;
			childName.SendMessage ("ForceUpdateDisplay", entry);
		}
	}

	void UpdateDate(string entry) {
		if (transform.Find ("ItineraryEntryColumnDate") != null) {
			GameObject childDate = transform.Find ("ItineraryEntryColumnDate").gameObject;
			childDate.SendMessage ("ForceUpdateDisplay", entry);
		}
	}

	void UpdateAdditional(string entry) {
		if (transform.Find ("ItineraryEntryColumnAdditional") != null) {
			GameObject childAdditional = transform.Find ("ItineraryEntryColumnAdditional").gameObject;
			childAdditional.SendMessage ("ForceUpdateDisplay", entry);
		}
	}


	public void SetRelativePosition(float x, float y, float z) {
		transform.localPosition = new Vector3(x, y, z);
	}

}
