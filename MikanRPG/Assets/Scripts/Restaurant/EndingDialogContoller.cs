using UnityEngine;
using System.Collections;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> origin/master
using UnityEngine.UI;

public class EndingDialogContoller : MonoBehaviour {

	public static EndingDialogContoller instance;

	public Text mainText;
	public Text money;
<<<<<<< HEAD

=======
	public Canvas endingDialog;

	void Start(){
		endingDialog = endingDialog.GetComponent<Canvas> ();
		endingDialog.enabled = false;
		Debug.Log ("start");
	}
>>>>>>> origin/master

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy(this);
		}
<<<<<<< HEAD
		
	}
	
=======

	}


>>>>>>> origin/master
	public void gameOver(int score){
		if (score <= 0) {
			mainText.text = "Game Over. Please practice more";
			score = 0;
		} else if (score <= 3) {
			mainText.text = "You could do better. Practice more";
		} else if (score <= 5) {
			mainText.text = "Not bad. A little practice can help";
		} else if (score == 6) {
			mainText.text = "Almost perfect. Great job";
		} else {
			mainText.text = "Perfect!";
		}

		int earned = score * 100;

		money.text = "" + earned;

		stopGame ();
<<<<<<< HEAD
		GetComponent<Animator> ().SetBool ("active", true);

=======

		//gameObject.GetComponent<Canvas> ().enabled = true;
		//Canvas[] children = gameObject.GetComponentsInChildren<Canvas>();
		//foreach(Canvas child in children){
		//	child.enabled = true;
		//}

		GetComponent<Animator> ().SetBool ("active", true);


>>>>>>> origin/master
	}

	private void stopGame(){
		RestaurantGlobals.stop = true;
	}
}
