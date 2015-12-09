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
		f.a = val;
		g.GetComponent<SpriteRenderer> ().color = f;
	}
	
	// Update the text on the itinerary entry
	public override void ForceUpdateDisplay(string entry) {
		string[] entries = entry.Split ('|');
		bool destroyFood = true;
		bool destroySS = true;
		bool destroyS = true;
	
		foreach (string e in entries) {
			if(e.Equals("food"))
			{
				destroyFood = false;
			}

			if(e.Equals("sightseeing"))
			{
				destroySS = false;
			}

			if(e.Equals("stay"))
			{
				destroyS = false;
			}
		}


		if (destroyFood) {
			food = gameObject.transform.Find ("Food").transform.gameObject;
			Destroy (food);
		}

		if (destroySS) {
			ss = gameObject.transform.Find("Sightseeing").transform.gameObject;
			Destroy (ss);
		}

		if (destroyS) {
			stay = gameObject.transform.Find("Stay").transform.gameObject;
			Destroy (stay);
		}


	}
}
