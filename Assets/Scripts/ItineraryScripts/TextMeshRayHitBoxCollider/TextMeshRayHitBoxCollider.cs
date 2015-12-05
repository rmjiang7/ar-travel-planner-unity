using UnityEngine;
using System.Collections;

public class TextMeshRayHitBoxCollider : MonoBehaviour {

	void OnRayHit() {
	}

	void UpdateBoxCollider() {
		// destroy old box collider
		Destroy (GetComponent<BoxCollider> ());
		BoxCollider bc = gameObject.AddComponent<BoxCollider> ();
		bc.isTrigger = false;
		bc.size = GetComponent<TextMesh> ().GetComponent<Renderer> ().bounds.size;
		if (transform.parent != null) {
			Vector3 offset = new Vector3 (bc.size.x / 2, -bc.size.y / 2, 0);
			bc.center = transform.localPosition + offset;
		}
	}

}
