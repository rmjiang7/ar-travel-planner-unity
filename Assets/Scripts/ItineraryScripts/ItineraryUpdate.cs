using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItineraryUpdate : MonoBehaviour {

	// array of plans
	private IList<GameObject> itinerary;

	// Base Itinerary Object to duplicate
	private GameObject baseItineraryEntry;

	public float maxTextBoxHeight = 1.0f;
	private int entryCount = 0;
	
	// Use this for initialization
	void Start () {
		itinerary = new List<GameObject> ();
		baseItineraryEntry = GameObject.Find ("ItineraryEntry");
	}

	// remove an entry from the list
	void Remove (int idx){
		Destroy(itinerary[idx]);
		itinerary.RemoveAt (idx);
		entryCount--;
	}

	void Add (string entry) {

		GameObject itineraryEntry = 
			(GameObject) Instantiate (baseItineraryEntry, 
			             baseItineraryEntry.transform.position + new Vector3(0,-maxTextBoxHeight*++entryCount,0),
			             Quaternion.identity);

		itineraryEntry.transform.parent = transform;
		itineraryEntry.transform.localScale = baseItineraryEntry.transform.localScale;

		itineraryEntry.SendMessage ("UpdateText", entry);
		itineraryEntry.SendMessage ("UpdateDate", "11/16");
		itinerary.Add (itineraryEntry);
		entryCount++;
	}

	// Update is called once per frame
	void Update () {
	}
}
