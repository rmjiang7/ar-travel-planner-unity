using UnityEngine;
using System.Collections;

public class SelectableLandmark : MonoBehaviour {

	protected bool isSelected = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public virtual void OnSelect() {
		transform.localScale = new Vector3(0.5f,0.5f,0.5f);
	}

	public virtual void OnDeselect() {
		transform.localScale = new Vector3(0.1f,0.1f,0.1f);
	}

	void ToggleSelect() {
		if(!isSelected) {
			GameObject go = 
				GameObject.FindGameObjectWithTag("SelectedLandmark");
			if(go != null) {
				go.GetComponent<SelectableLandmark>().SendMessage ("ToggleSelect");
			}
			isSelected = true;
			gameObject.tag = "SelectedLandmark";
			OnSelect();
		} else {

			isSelected = false;
			gameObject.tag = "Untagged";
			OnDeselect();
		}
	}
}
