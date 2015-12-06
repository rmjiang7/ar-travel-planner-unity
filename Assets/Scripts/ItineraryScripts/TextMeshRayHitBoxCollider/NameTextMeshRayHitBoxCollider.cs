using UnityEngine;
using System.Collections;

[RequireComponent (typeof (TextItineraryEntryColumn))]
public class NameTextMeshRayHitBoxCollider : TextMeshRayHitBoxCollider {

	public override void OnRayHit() {
		GetComponent<ItineraryEntryColumn> ().SendMessage ("UpdateText", "Changed!");
	}

}
