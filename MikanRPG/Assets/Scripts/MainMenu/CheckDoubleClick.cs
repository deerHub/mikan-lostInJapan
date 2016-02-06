using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CheckDoubleClick : MonoBehaviour {

	
	private float doubleClickTime = .5f;
	private float lastClickTime = -10f;
	private Canvas profileModal;
	private Canvas mainMenuOptions;
	private Camera mainMenu;

	private ProfileButton button;
	private Button deleteBtn;
	private Button profileBtn;
	public static string profileNameClicked;

	void Start(){
	
		profileModal = gameObject.GetComponentInParent<Canvas> ();
		mainMenu = profileModal.GetComponentInParent<Camera> ();
		mainMenuOptions = mainMenu.transform.Find("Main Menu").GetComponent<Canvas>();
		button = gameObject.GetComponent<ProfileButton> ();
		profileBtn = mainMenuOptions.transform.Find ("Profile Button").GetComponent<Button> ();

		if (profileBtn != null) {
			Debug.Log ("Found " + profileBtn.name);
		}

		if (button != null) {
			button.button.onClick.AddListener (() =>
				ClickProfileName (button.profileName.text, button.button)
			);
		}
	
	}

	void OnGUI(){
	
		Event mouse = Event.current;
		int count = mouse.clickCount;

		if (count < 2) {

			Debug.Log(count + " clicks");
			
		}else if (count == 2) {

			Debug.Log(count + " clicks");
			Debug.Log(mouse.type);

			button = gameObject.GetComponent<ProfileButton> ();
			if (button != null) {
				//button.button.onClick.AddListener (() =>
				//	SetProfileName (button.profileName.text, button.button)
				//);

				string profileName = button.profileName.text;
				Debug.Log (profileName);
				SaveLoad.list.latestGame = profileName;
				Game.current = new Game ();
				Game.current = SaveLoad.list.savedGames.Find(x => x.currentProfile.profileName == profileName);
				SaveLoad.Save();
				profileBtn.GetComponentInChildren<Text> ().text = profileName;
				Debug.Log (SaveLoad.list.latestGame	);

			}
		
		}
	
	}

	void Update (){

		if (Input.GetMouseButtonDown (0)) {
			float timeDelta = Time.time - lastClickTime;

			button = gameObject.GetComponent<ProfileButton> ();
			
			if (timeDelta < doubleClickTime) {

				lastClickTime = 0;
				profileModal.enabled = false;
				/*
				if (button != null) {
					button.button.onClick.AddListener (() =>
						SetProfileName (button.profileName.text, button.button)
					);
				}
				*/
			
			} else {

				lastClickTime = Time.time;

				if (button != null) {

				}

			}
		}

	}

	void SetProfileName(string profileName, Button btn){
		
		Debug.Log (profileName);
		profileNameClicked = profileName;
		SaveLoad.list.latestGame = profileName;
		Game.current = new Game ();
		Game.current = SaveLoad.list.savedGames.Find(x => x.currentProfile.profileName == profileName);
		profileBtn.GetComponentInChildren<Text> ().text = profileName;
		Debug.Log (SaveLoad.list.latestGame	);
		
	}

	void ClickProfileName(string profileName, Button btn){

		Debug.Log (profileName);
		profileNameClicked = profileName;
		deleteBtn = profileModal.transform.FindChild("DeleteBtn").GetComponent<Button>();
		
		if (deleteBtn != null){
			
			Debug.Log("Found " + deleteBtn.name);
			deleteBtn.image.enabled = true;
			deleteBtn.enabled = true;
			deleteBtn.interactable = true;
			
		}
		
	}

}
