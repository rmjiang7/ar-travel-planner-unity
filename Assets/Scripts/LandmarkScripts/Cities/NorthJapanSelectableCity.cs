using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NorthJapanSelectableCity : SelectableCity {
	
	private GameObject uiInfoPanel;
	// Update is called once per frame
	protected override void Start () {
		base.Start ();
		uiInfoPanel = GameObject.Find ("UIInfoPanel");
	}

	public override void OnSelect() {
		base.OnSelect ();
		CanvasGroup cv = uiInfoPanel.GetComponent<CanvasGroup> ();
		cv.alpha = 1.0f;
		cv.interactable = true;

		GameObject pt = uiInfoPanel.transform.FindChild ("PageTitle").transform.gameObject;
		pt.GetComponent<Text> ().text = gameObject.name; 
	}

	public override void OnDeselect() {
		base.OnDeselect ();
		CanvasGroup cv = uiInfoPanel.GetComponent<CanvasGroup> ();
		cv.alpha = 0.0f;
		cv.interactable = false;
	}
}
