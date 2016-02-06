using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemSelectedController : MonoBehaviour {

	private static ItemController item;
	public static string text = "none";

	public Text myText;
	public InputField input;
	public Button btn;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		myText.text = text;
		if (text == "none") {
			enableInput(false);
		} else {
			enableInput(true);
		}
	}

	public static void selectMe(ItemController other){
		if (item != null) {
			item.deselect ();

			if (item.name != other.name) {
				item = other;
				text = item.getText();
			} else {
				item = null;
				text = "none";
			}

		} else {
			item = other;
			text = item.getText();

		}


	}

	public static ItemController getSelectedItem(){
		return item;
	}


	
	public void enableInput(bool enable){
		input.enabled = enable;
		btn.enabled = enable;
	}


}
