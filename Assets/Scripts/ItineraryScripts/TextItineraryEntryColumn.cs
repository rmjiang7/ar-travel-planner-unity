using UnityEngine;
using System.Collections;

[RequireComponent (typeof (TextMesh))]
public class TextItineraryEntryColumn : ItineraryEntryColumn {

	// Use this for initialization
	void Start () {
	}
	
	// Update the text on the itinerary entry
	public override void ForceUpdateDisplay(string entry) {
		GetComponent<TextMesh> ().text = entry;
	}
}
