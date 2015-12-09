using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NorthJapanSelectableCity : SelectableCity {

	public Texture2D landmarkSprite;
	[TextArea(3,10)]
	public string text;
	
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
		GameObject pt = uiInfoPanel.transform.FindChild ("InfoScroll").transform.gameObject;
		string textspaced = "\n\n" + text;
		pt.transform.Find ("Viewport").transform.Find ("Content").GetComponent<Text> ().text = textspaced;
	}

	public override void OnDeselect() {
		base.OnDeselect ();
		CanvasGroup cv = uiInfoPanel.GetComponent<CanvasGroup> ();
		cv.alpha = 0.0f;
		cv.interactable = false;
	}
}
