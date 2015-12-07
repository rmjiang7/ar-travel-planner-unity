using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SelectableLandmark))]
public class AddToItineraryAction : MonoBehaviour {

	public string message;

	private GameObject itinerary;
	private SelectableLandmark parentLandmark;

	private Vector3 startPos;
	private float minSwipeDistY = 400.0f;

	// Use this for initialization
	void Start () {
		itinerary = GameObject.Find ("ItineraryPlane");
		parentLandmark = GetComponent<SelectableLandmark> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (parentLandmark.selected()) {
			if (Input.touchCount != 0) {
				Touch touch = Input.GetTouch (0);
				switch (touch.phase) {
				case TouchPhase.Began:
					startPos = touch.position;
					break;
				case TouchPhase.Ended:
					float swipeDistVertical = 
						(new Vector3 (0, touch.position.y, 0) -
						 new Vector3 (0, startPos.y, 0)).magnitude;
					if (swipeDistVertical > minSwipeDistY) {
						itinerary.SendMessage("Add",message);
					}
					break;
				default:
					break;
				}
			}
		}
		*/

		if (parentLandmark.selected()) {
			if (Input.GetMouseButtonDown(0)) {
				itinerary.SendMessage ("Add", new string[] {message,message});
				Destroy (GetComponent<AddToItineraryAction>());

				MarkerPlacement gc = 
					(MarkerPlacement) gameObject.AddComponent<MarkerPlacement>();
				gc.X = transform.position.x;
				gc.Z = transform.position.z;

				GameObject primitive = 
					GameObject.CreatePrimitive(PrimitiveType.Sphere);
				primitive.active = false;
				Material diffuse = 
					primitive.GetComponent<MeshRenderer>().sharedMaterial;
				gc.selectedMesh = primitive.GetComponent<MeshFilter>().mesh;
				gc.selectedMeshMaterial = diffuse;

				SelectableLandmark sm = GetComponent<SelectableLandmark>();
				sm.selectedMesh = primitive.GetComponent<MeshFilter>().mesh;
				sm.selectedMeshMaterial = diffuse;
				sm.deselectedMesh = primitive.GetComponent<MeshFilter>().mesh;
				sm.deselectedMeshMaterial = diffuse;

				DestroyImmediate(primitive);

				Vacuum vac = (Vacuum) gameObject.AddComponent<Vacuum>();
				vac.X = transform.position.x;
				vac.Z = transform.position.z;

			}

			if (Input.GetMouseButtonDown (1)) {
				itinerary.SendMessage ("Remove", message);
			}
		}
	}
}
