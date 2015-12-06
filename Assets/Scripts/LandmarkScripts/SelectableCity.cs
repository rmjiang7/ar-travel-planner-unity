using UnityEngine;
using System.Collections;

public class SelectableCity : SelectableLandmark {

	public Mesh deselectedMesh;
	public Material deselectedMeshMaterial;

	public Mesh selectedMesh;
	public Material selectedMeshMaterial;


	// Use this for initialization
	void Start () {
		GetComponent<MeshFilter> ().mesh = deselectedMesh;
		GetComponent<MeshRenderer> ().materials = new Material[]{deselectedMeshMaterial};
		transform.localScale = new Vector3(0.1f,0.1f,0.1f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public override void OnSelect() {
		GetComponent<MeshFilter> ().mesh = selectedMesh;
		GetComponent<MeshRenderer> ().materials = new Material[]{selectedMeshMaterial};
		transform.localScale = new Vector3(0.5f,0.5f,0.5f);
	}

	public override void OnDeselect() {
		GetComponent<MeshFilter> ().mesh = deselectedMesh;
		GetComponent<MeshRenderer> ().materials = new Material[]{deselectedMeshMaterial};
		transform.localScale = new Vector3(0.1f,0.1f,0.1f);
	}


}
