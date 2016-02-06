using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class CreateFirstProfile : MonoBehaviour {

	public Canvas profileNamePrompt;
	public Text profileBtnText;
	public InputField profileName;
	public Text warningText;

	private Game gameProfile;
	public static int profileLength = 10;

	// Use this for initialization
	void Start () {

		profileNamePrompt = profileNamePrompt.GetComponent<Canvas> ();
		profileBtnText = profileBtnText.GetComponent<Text> ();
		profileName = profileName.GetComponent<InputField> ();
		warningText = warningText.GetComponent<Text>();
		warningText.text = "";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PressEnterProfileName(){
		if (profileName.text == "" || profileName.text == " ") {
			
			warningText.text = "Please enter a name";
				
		}else if (profileName.text.Length > profileLength) {

			warningText.text = "Name should be" + profileLength + "characters.";
		
		}
		else {

			Game.current = new Game();
			Game.current.currentProfile.profileName = profileName.text;
			SaveLoad.list.latestGame = profileName.text;
			//Debug.Log(Game.current.currentProfile.profileName);

			SaveLoad.Save();

			profileNamePrompt.enabled = false;

			profileBtnText.text = SaveLoad.list.latestGame;

		}
	}

	public void Validate(){
		if (profileName.text.Length > CreateFirstProfile.profileLength) {

			warningText.text = "Name should not be more than " + CreateFirstProfile.profileLength + " characters.";
		
		}
		if (profileName.text.Length <= CreateFirstProfile.profileLength){
		
			warningText.text = "";

		}
	}
}
