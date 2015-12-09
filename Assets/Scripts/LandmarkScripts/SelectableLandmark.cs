using UnityEngine;
using System.Collections;

public class SelectableLandmark : MonoBehaviour {

	protected bool isSelected = false;
	
	public Mesh deselectedMesh;
	public Material[] deselectedMeshMaterials;
	
	public Mesh selectedMesh;
	public Material[] selectedMeshMaterials;

	public Vector3 selectedScale = new Vector3(1f,1f,1f);
	public Vector3 deselectedScale = new Vector3(1f,1f,1f);

	// Use this for initialization
	void Start () {
		transform.localScale = deselectedScale;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public virtual void OnSelect() {
		GetComponent<MeshFilter> ().mesh = deselectedMesh;
		GetComponent<MeshRenderer> ().materials = deselectedMeshMaterials;
		transform.localScale = selectedScale;
	}

	public virtual void OnDeselect() {
		GetComponent<MeshFilter> ().mesh = selectedMesh;
		GetComponent<MeshRenderer> ().materials = selectedMeshMaterials;
		transform.localScale = deselectedScale;
	}

	void ToggleSelect() {
		Debug.Log ("Has Toggled Selected");
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

	public bool selected() {
		return this.isSelected;
	}

	public void ForceDisplayUpdate(){
		if (isSelected) {
			OnSelect ();
		} else {
			OnDeselect ();
		}
	}	
}
