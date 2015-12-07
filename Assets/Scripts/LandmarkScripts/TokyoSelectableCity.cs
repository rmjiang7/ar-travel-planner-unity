using UnityEngine;
using System.Collections;

public class TokyoSelectableCity : SelectableCity {
	
	private GameObject uiInfoPanel;
	// Update is called once per frame
	protected override void Start () {
		base.Start ();
		uiInfoPanel = GameObject.Find ("UIInfoPanel");
	}

	public override void OnSelect() {
		base.OnSelect ();
		uiInfoPanel.GetComponent<CanvasGroup>().alpha = 1.0f;
	}

	public override void OnDeselect() {
		base.OnDeselect ();
		uiInfoPanel.GetComponent<CanvasGroup>().alpha = 0.0f;
	}
}
