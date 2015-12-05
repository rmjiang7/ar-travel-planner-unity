using UnityEngine;
using System.Collections;

public class DateTextMeshRayHitBoxCollider : TextMeshRayHitBoxCollider {
	void OnRayHit() {
		GetComponent<ItineraryEntryColumn> ().SendMessage ("UpdateText", "11/17");
	}
}
