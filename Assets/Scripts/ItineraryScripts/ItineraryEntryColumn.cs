using UnityEngine;
using System.Collections;

public class ItineraryEntryColumn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	// Update the text on the itinerary entry
	void UpdateText(string entry) {
		GetComponent<TextMesh> ().text = entry;
	}
}
