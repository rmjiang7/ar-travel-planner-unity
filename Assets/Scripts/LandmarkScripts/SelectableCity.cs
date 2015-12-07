using UnityEngine;
using System.Collections;

public class SelectableCity : SelectableLandmark {
	
	private float time = 0f;

	public Mesh deselectedMesh;
	public Material deselectedMeshMaterial;

	public Mesh selectedMesh;
	public Material selectedMeshMaterial;

	public float pulseDuration = 500;
	public float pulseScaleMultiplier = 1.5f;

	private Vector3 initialScale;
	private Vector3 finalScale;

	// Use this for initialization
	protected virtual void Start () {
		GetComponent<MeshFilter> ().mesh = deselectedMesh;
		GetComponent<MeshRenderer> ().materials = new Material[]{deselectedMeshMaterial};
		transform.localScale = new Vector3(0.1f,0.1f,0.1f);
		time = Time.time * 1000;
	}
	
	// Update is called once per frame
	void Update () {
		if (isSelected) {
			float newTime = Time.time * 1000;
			Vector3 scaleInt = (finalScale-initialScale) * ((newTime - time) / pulseDuration);
			transform.localScale = initialScale + scaleInt;
			if(newTime - time > pulseDuration) {
				time = newTime;
				Vector3 temp = initialScale;
				initialScale = finalScale;
				finalScale = temp;
			}
		}
	}

	public override void OnSelect() {
		GetComponent<MeshFilter> ().mesh = selectedMesh;
		GetComponent<MeshRenderer> ().materials = new Material[]{selectedMeshMaterial};
		transform.localScale = new Vector3(0.5f,0.5f,0.5f);
		initialScale = transform.localScale;
		finalScale = transform.localScale * pulseScaleMultiplier;
		time = Time.time * 1000;
	}

	public override void OnDeselect() {
		GetComponent<MeshFilter> ().mesh = deselectedMesh;
		GetComponent<MeshRenderer> ().materials = new Material[]{deselectedMeshMaterial};
		transform.localScale = new Vector3(0.1f,0.1f,0.1f);
	}


}
