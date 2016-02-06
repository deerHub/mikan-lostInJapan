using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Events;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class MainMenu: MonoBehaviour {

	public Canvas optionsMenu;
	public Canvas exitMenu;
	public Canvas profileMenu;	
	public Canvas profileNamePrompt;
	public Image callout;
	public Button profileBtn;
	public Button playBtn;
	public Button exitBtn;
	public Button optionBtn;
	public Button addBtn;
	public Button deleteBtn;

	public InputField newName;
	public Text calloutText;

	public GameObject profileButton;
	public Transform contentPanel;

	private string newNameInput = "";

	// Use this for initialization
	void Start () {

		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		profileNamePrompt = profileNamePrompt.GetComponent<Canvas>();
		profileMenu = profileMenu.GetComponent<Canvas> ();

		profileBtn = profileBtn.GetComponent<Button> ();
		playBtn = playBtn.GetComponent<Button> ();
		exitBtn = exitBtn.GetComponent<Button> ();
		optionBtn = optionBtn.GetComponent<Button> ();
		addBtn = addBtn.GetComponent<Button> ();
		deleteBtn = deleteBtn.GetComponent<Button> ();



		//List<string> name = new List<string> ();

		foreach(Game game in SaveLoad.list.savedGames){
		

		}

		deleteBtn.onClick.AddListener(delegate{
			
			DeletProfile(CheckDoubleClick.profileNameClicked , deleteBtn);
			
		});


		callout = callout.GetComponent<Image> ();

		newName = newName.GetComponent<InputField> ();

		calloutText = calloutText.GetComponent<Text> ();

		optionsMenu.enabled = false;
		profileMenu.enabled = false;
		callout.enabled = false;
		calloutText.enabled = false;
		addBtn.interactable = false;
		deleteBtn.enabled = false;
		deleteBtn.image.enabled = false;

		if (File.Exists (Application.persistentDataPath + "/" + SaveLoad.fileName)) {

			Debug.Log("FileExists");
			SaveLoad.Load ();
			profileNamePrompt.enabled = false;
			profileBtn.GetComponentInChildren<Text>().text = SaveLoad.list.latestGame;
			//Create Game.current object from latest profile used.
		
		} else {

			Debug.Log("No file");
			profileNamePrompt.enabled = true;
		
		}

		Debug.Log (SaveLoad.list.savedGames.Count);
	}

	public void ExitPress(){
	
		exitMenu.enabled = true;
		playBtn.enabled = false;
		optionBtn.enabled = false;
		exitBtn.enabled = false;
		Debug.Log ("Exit pressed");
	
	}

	public void OptionsPress(){
	
		optionsMenu.enabled = true;
		playBtn.enabled = false;
		optionBtn.enabled = false;
		exitBtn.enabled = false;

	}

	public void ProfilePress(){
	
		profileMenu.enabled = true;
		PopulateList ();
		Debug.Log ("press profile");
	
	}

	void PopulateList(){

		Debug.Log ("Populate");
		DepopulateList ();

		foreach (var game in SaveLoad.list.savedGames){

			GameObject newButton = Instantiate(profileButton) as GameObject;
			newButton.AddComponent<CheckDoubleClick>();
			ProfileButton button = newButton.GetComponent<ProfileButton>();
			button.profileName.text = game.currentProfile.profileName;
			//button.button.onClick.AddListener(delegate{
			//	GetProfileName(button.profileName.text, button.button);
			//});
			newButton.transform.SetParent(contentPanel);

		}

	}

	void DepopulateList(){
	
		var children = new List<GameObject>();
		foreach (Transform child in contentPanel) {
			children.Add (child.gameObject);
		}
		children.ForEach(child => Destroy(child));
		Debug.Log ("Removed profile Buttons");
	
	}

	void GetProfileName(string profileName, Button button){

		Debug.Log (profileName);
		button.onClick.AddListener (delegate {
			GetProfileName(profileName, button);
		});
		//button.onClick.RemoveAllListeners ();
		Debug.Log(button.onClick.GetPersistentEventCount ());

	}

	public void ValidateAddProfile(){

		newNameInput = newName.text;

		if (newNameInput.Length > CreateFirstProfile.profileLength) {
		
			callout.enabled = true;
			calloutText.enabled = true;

			calloutText.text = "Maximum length is " + CreateFirstProfile.profileLength;

			addBtn.interactable = false;
		
		} else if (newNameInput.Length <= CreateFirstProfile.profileLength) {
		
			callout.enabled = false;
			calloutText.enabled = false;
			Debug.Log("okLength, check name exist");
		
			if (SaveLoad.list.savedGames.Exists(x => x.currentProfile.profileName == newNameInput) == true){
				
				callout.enabled = true;
				calloutText.text = "Name exists";
				calloutText.enabled = true;
				addBtn.interactable = false;
				Debug.Log("not ok name");
				
			}
			
			else {
				
				addBtn.interactable = true;
				callout.enabled = false;
				calloutText.enabled = false;
				Debug.Log("everything ok");
				
			}
		
		}

	}

	public void AddProfile(){
	
		if (newNameInput == "") {
		
			callout.enabled = true;
			calloutText.text = "Enter a name";
			calloutText.enabled = true;
		
		} else {
		
			Game newGame = new Game();
			newGame.currentProfile.profileName = newNameInput;
			SaveLoad.AddSavedGame(newGame);
			Debug.Log ("Added " + newNameInput);
			newName.text = "";
			DepopulateList();
			PopulateList();

		}
	
	}

	private void DeletProfile(string name, Button btn){
		
		SaveLoad.DeleteGame (name);
		DepopulateList ();
		PopulateList();
		btn.onClick.RemoveAllListeners ();
		
	}


	public void OkOptions(){
		
		optionsMenu.enabled = false;
		playBtn.enabled = true;
		optionBtn.enabled = true;
		exitBtn.enabled = true;
		
	}

	public void NoPress(){
	
		exitMenu.enabled = false;
		playBtn.enabled = true;
		optionBtn.enabled = true;
		exitBtn.enabled = true;
		
	}

	public void StartPlay(){
	
		Application.LoadLevel (3);

	
	}

	public void ExitGame(){
	
		Application.Quit ();	
	
	}

}
