using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItineraryUpdate : MonoBehaviour {

	// array of plans
	private IList<GameObject> itinerary;
	private IList<Vector3> landmarkPositions;
	private Dictionary<string, int> entryLookupTable;
    private IList<ArrowArcs> arcs;

	// Base Itinerary Object to duplicate
	private GameObject baseItineraryEntry;

	public float maxTextBoxHeight = 1.0f;
	private int entryCount = 0;
	
	// Use this for initialization
	void Start () {
		itinerary = new List<GameObject> ();
		landmarkPositions = new List<Vector3> ();
		entryLookupTable = new Dictionary<string, int> ();
		baseItineraryEntry = GameObject.Find ("ItineraryEntry");
	}

	// remove an entry from the list
	void Remove (string key){
		Debug.Log ("Remove");
		int idx = entryLookupTable [key];
		Destroy(itinerary[idx]);
		itinerary.RemoveAt (idx);
		landmarkPositions.RemoveAt (idx);
		entryLookupTable.Remove (key);
		entryCount--;

        for (int i = 0; i < entryCount; i++) {
			itinerary[i].GetComponent<ItineraryEntryUpdate>().transform.position = baseItineraryEntry.transform.position + new Vector3(0,-maxTextBoxHeight*(i+1),0);
		}
    
		foreach(KeyValuePair<string, int> entry in entryLookupTable)
		{
			if(entry.Value > idx) {
				entryLookupTable[entry.Key] = entry.Value-1;
			}
		}

        for (int i = arcs.Count - 1; i >= 0; i--)
        {
            Debug.Log("deleting");
            arcs[i].destroyArc();
        }
        for (int i = 1; i < arcs.Count - 1; i++)
        {
            Debug.Log("rerendering");
            ArrowArcs arrow =
                 gameObject.AddComponent<ArrowArcs>();
            arrow.X_start = landmarkPositions[i - 1].x;
            arrow.Z_start = landmarkPositions[i - 1].z;

            arrow.X = landmarkPositions[i].x;
            arrow.Z = landmarkPositions[i].z;

            arcs.Add(arrow);
        }

    }

	public void Add (string[] entrykeyvalues, Vector3 landmarkPosition) {
		string key = entrykeyvalues [0];
		string date = entrykeyvalues [1];
		string name = entrykeyvalues [2];
		string additional = entrykeyvalues [3];

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

		itineraryEntry.SendMessage ("UpdateDate", date);
		itineraryEntry.SendMessage ("UpdateName", name);
		itineraryEntry.SendMessage ("UpdateAdditional", additional);
		itinerary.Add (itineraryEntry);
		landmarkPositions.Add (landmarkPosition);
		entryLookupTable.Add (key, entryCount - 1);


        if (entryCount > 1)
        {
            ArrowArcs arrow =
                gameObject.AddComponent<ArrowArcs>();
            arrow.X_start = landmarkPositions[entryCount - 2].x;
            arrow.Z_start = landmarkPositions[entryCount - 2].z;
            
            arrow.X = landmarkPositions[entryCount-1].x;
            arrow.Z = landmarkPositions[entryCount-1].z;

            arcs.Add(arrow);
        }
    }

	// Update is called once per frame
	void Update () {
	}
}
