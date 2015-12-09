using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SelectableLandmark))]
public class AddToItineraryAction : MonoBehaviour {
	
	public string date = "";
	public string name = "";
	public string additional = "";

	private GameObject itinerary;
	private SelectableLandmark parentLandmark;

	private Vector3 startPos;
	private float minSwipeDistY = 400.0f;

	public Mesh oldSelectedMesh = null;
	public Material[] oldSelectedMeshMaterials = null;

	public Mesh oldDeselectedMesh = null;
	public Material[] oldDeselectedMeshMaterials =  null;

	public Mesh addedMesh = null;
	public Material[] addedMeshMaterials = null;

	private bool hasBeenAdded = false;

	public Vector3 addedScaleSelected = new Vector3(1f,1f,1f);
	public Vector3 addedScaleDeselected = new Vector3(1f,1f,1f);

	private Vector3 tempScaleSelected;
	private Vector3 tempScaleDeselected;

	// Use this for initialization
	void Start () {
		itinerary = GameObject.Find ("ItineraryPlane");
		parentLandmark = GetComponent<SelectableLandmark> ();;
	}

	void AddToItinerary() {
		if(!hasBeenAdded){
			itinerary.GetComponent<ItineraryUpdate>().Add(new string[] {gameObject.name, date, name, additional}, gameObject.transform.position);
			
			MarkerPlacement gc = 
				(MarkerPlacement) gameObject.AddComponent<MarkerPlacement>();
			gc.X = transform.position.x;
			gc.Z = transform.position.z;
			
			gc.selectedMesh = addedMesh;
			gc.selectedMeshMaterials = addedMeshMaterials;
			
			parentLandmark.selectedMesh = addedMesh;
			parentLandmark.selectedMeshMaterials = addedMeshMaterials;
			parentLandmark.deselectedMesh = addedMesh;
			parentLandmark.deselectedMeshMaterials = addedMeshMaterials;

			tempScaleSelected = parentLandmark.selectedScale;
			tempScaleDeselected = parentLandmark.deselectedScale;

			parentLandmark.selectedScale = addedScaleSelected;
			parentLandmark.deselectedScale = addedScaleDeselected;
			
			hasBeenAdded = true;
		}
	}

	void RemoveFromItinerary() {
		if(hasBeenAdded) {
			itinerary.SendMessage ("Remove", gameObject.name);
			
			Destroy (GetComponent<MarkerPlacement>());
			
			parentLandmark.selectedMesh = oldSelectedMesh;
			parentLandmark.selectedMeshMaterials = oldSelectedMeshMaterials;
			parentLandmark.deselectedMesh = oldSelectedMesh;
			parentLandmark.deselectedMeshMaterials = oldSelectedMeshMaterials;
			parentLandmark.ForceDisplayUpdate();
			
			hasBeenAdded = false;

			parentLandmark.selectedScale = tempScaleSelected;
			parentLandmark.deselectedScale = tempScaleDeselected;
		}
	}
	
	// Update is called once per frame
	void Update () {

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
						if(startPos.y < touch.position.y) {
							AddToItinerary();
						} else {
							RemoveFromItinerary();
						}
					}
					break;
				default:
					break;
				}
			}
		}

		if (parentLandmark.selected()) {
			if (Input.GetMouseButtonDown(0)) {
				AddToItinerary();
			}

			if (Input.GetMouseButtonDown (1)) {
				RemoveFromItinerary();
			}
		}
	}
}
