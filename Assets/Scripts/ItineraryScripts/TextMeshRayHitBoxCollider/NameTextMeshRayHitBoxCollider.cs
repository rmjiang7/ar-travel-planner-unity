using UnityEngine;
using System.Collections;

public class NameTextMeshRayHitBoxCollider : TextMeshRayHitBoxCollider {

	void OnRayHit() {
		GetComponent<ItineraryEntryColumn> ().SendMessage ("UpdateText", "Changed!");
	}
}
