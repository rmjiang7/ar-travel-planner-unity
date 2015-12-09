using UnityEngine;
using System.Collections;

public class SymbolItineraryEntryColumn : MonoBehaviour {

	private GameObject food;
	private GameObject ss;
	private GameObject stay;

	// Use this for initialization
	void Start () {
		food = gameObject.transform.FindChild("Food").transform.gameObject;
		ss = gameObject.transform.FindChild("Sightseeing").transform.gameObject;
		stay = gameObject.transform.FindChild("Stay").transform.gameObject;

		ChangeAlpha (food, 255.0f);
		ChangeAlpha (ss, 255.0f);
		ChangeAlpha (stay, 255.0f);
	}

	void ChangeAlpha(GameObject g, float val) {
		Color f = g.GetComponent<SpriteRenderer>().color;
		f.a = val;
		g.GetComponent<SpriteRenderer> ().color = f;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	// Update the text on the itinerary entry
	void ForceUpdateDisplay(string entry) {
		/*
		string[] entries = entry.Split ('|');
		foreach (string e in entries) {
			if(e.Equals("food"))
			{
				ChangeAlpha(food,255.0f);
			}

			if(e.Equals("sightseeing"))
			{
				ChangeAlpha(ss,255.0f);
			}

			if(e.Equals("stay"))
			{
				ChangeAlpha(stay, 255.0f);
			}
		}
		*/
	}
}
