using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItineraryUpdate : MonoBehaviour {

	// array of plans
	private IList<string> plans;
	private bool isDirty = false;

	// Use this for initialization
	void Start () {
		plans = new List<string> ();
		Redraw ();
	}

	// remove an entry from the list
	void Remove (int idx){
		plans.RemoveAt (idx);
		isDirty = true;
	}

	void Add (string entry) {
		plans.Add (entry);
		isDirty = true;
	}

	void Redraw() {
		string outstring = "";
		for (int i = 0; i < plans.Count; i++) {
			outstring += (i+1).ToString() + ": " + plans[i] + "\n";
		}
		GetComponent<TextMesh> ().text = outstring;
	}

	// Update is called once per frame
	void Update () {
		if (isDirty) {
			Redraw ();
			isDirty = false;
		}
	}
}
