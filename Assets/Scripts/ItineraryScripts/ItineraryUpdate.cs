using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItineraryUpdate : MonoBehaviour {

	// array of plans
	private IList<GameObject> itinerary;
	private Dictionary<string, int> entryLookupTable; 

	// Base Itinerary Object to duplicate
	private GameObject baseItineraryEntry;

	public float maxTextBoxHeight = 1.0f;
	private int entryCount = 0;
	
	// Use this for initialization
	void Start () {
		itinerary = new List<GameObject> ();
		entryLookupTable = new Dictionary<string, int> ();
		baseItineraryEntry = GameObject.Find ("ItineraryEntry");
	}

	// remove an entry from the list
	void Remove (string key){
		Debug.Log ("Remove");
		int idx = entryLookupTable [key];
		Destroy(itinerary[idx]);
		itinerary.RemoveAt (idx);
		entryLookupTable.Remove (key);
		entryCount--;
	}

	void Add (string[] entrykeypair) {
		string entry = entrykeypair [0];
		string key = entrykeypair [1];

		if (entryLookupTable.ContainsKey (key)) {
			Debug.Log ("Entry does not exist");
			return;
		}

		GameObject itineraryEntry = 
			(GameObject) Instantiate (baseItineraryEntry, 
			             baseItineraryEntry.transform.position + new Vector3(0,-maxTextBoxHeight*++entryCount,0),
			             Quaternion.identity);

		itineraryEntry.transform.parent = transform;
		itineraryEntry.transform.localScale = baseItineraryEntry.transform.localScale;

		itineraryEntry.SendMessage ("UpdateName", entry);
		itineraryEntry.SendMessage ("UpdateDate", "11/16");
		itinerary.Add (itineraryEntry);
		entryLookupTable.Add (key, entryCount - 1);
	}

	// Update is called once per frame
	void Update () {
	}
}
