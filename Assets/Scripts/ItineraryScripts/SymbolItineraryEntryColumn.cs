using UnityEngine;
using System.Collections;

public class SymbolItineraryEntryColumn : ItineraryEntryColumn {

	private GameObject food;
	private GameObject ss;
	private GameObject stay;

	// Use this for initialization
	public virtual void Start () {
		food = gameObject.transform.FindChild("Food").transform.gameObject;
		ss = gameObject.transform.FindChild("Sightseeing").transform.gameObject;
		stay = gameObject.transform.FindChild("Stay").transform.gameObject;

		ChangeAlpha (food, 1.0f);
		ChangeAlpha (ss, 1.0f);
		ChangeAlpha (stay, 1.0f);
	}

	void ChangeAlpha(GameObject g, float val) {
		Color f = g.GetComponent<SpriteRenderer>().color;
		Color n = new Color (f.r, f.g, f.b, val);
		g.GetComponent<SpriteRenderer> ().color = n;
		Debug.Log (g.GetComponent<SpriteRenderer> ().color);
	}
	
	// Update the text on the itinerary entry
	public override void ForceUpdateDisplay(string entry) {
		string[] entries = entry.Split ('|');
		foreach (string e in entries) {
			if(e.Equals("food"))
			{
				food = gameObject.transform.FindChild("Food").transform.gameObject;
				ChangeAlpha(food,1.0f);
			}

			if(e.Equals("sightseeing"))
			{
				ss = gameObject.transform.FindChild("Sightseeing").transform.gameObject;
				ChangeAlpha(ss,1.0f);
			}

			if(e.Equals("stay"))
			{
				stay = gameObject.transform.FindChild("Stay").transform.gameObject;
				ChangeAlpha(stay, 1.0f);
			}
		}
	}
}
