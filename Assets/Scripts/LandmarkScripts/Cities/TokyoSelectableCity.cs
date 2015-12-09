using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TokyoSelectableCity : SelectableCity {

	public Texture2D landmarkSprite;

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

		UpdateImage ();
		UpdateText ();
		UpdateInfo ();
	}
	
	void UpdateImage() 
	{
		GameObject pt = uiInfoPanel.transform.FindChild ("LandmarkImage").transform.gameObject;
		pt.GetComponent<RawImage> ().texture = landmarkSprite;
	}
	
	void UpdateText() 
	{
		GameObject pt = uiInfoPanel.transform.FindChild ("PageTitle").transform.gameObject;
		pt.GetComponent<Text> ().text = gameObject.name; 
	}
	
	void UpdateInfo()
	{
	}

	public override void OnDeselect() {
		base.OnDeselect ();
		CanvasGroup cv = uiInfoPanel.GetComponent<CanvasGroup> ();
		cv.alpha = 0.0f;
		cv.interactable = false;
	}
}
