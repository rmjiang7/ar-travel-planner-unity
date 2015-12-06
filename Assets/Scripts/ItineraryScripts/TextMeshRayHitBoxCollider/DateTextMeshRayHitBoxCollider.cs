using UnityEngine;
using System.Collections;

[RequireComponent (typeof (TextItineraryEntryColumn))]
public class DateTextMeshRayHitBoxCollider : TextMeshRayHitBoxCollider {

	public override void OnRayHit() {
		GetComponent<ItineraryEntryColumn> ().SendMessage ("UpdateText", "11/17");
	}

}
