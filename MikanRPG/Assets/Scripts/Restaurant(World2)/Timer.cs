using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour {

	float time;
	float timeLeft = 34;

	public Canvas end;
	public Text timer;
	public bool start = false;
	public Transform controller;
	public Canvas disablingScreen;

	// Use this for initialization
	void Start () {
		timer = timer.GetComponent<Text> ();
		end = end.GetComponent<Canvas> ();
		disablingScreen = disablingScreen.GetComponent<Canvas> ();
		disablingScreen.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (start == true) {
			timeLeft -= Time.deltaTime;
		}

	}

	void OnGUI(){
	
		if (timeLeft > 4) {
			timer.text = ((int)timeLeft-4).ToString();
		} else {
			timer.text = "Time's up!";
			disablingScreen.enabled = true;
			if (timeLeft < 0){
			
				disablingScreen.enabled = false;
				end.enabled = true;
				end.transform.Find("Money earned").GetComponent<Text>().text = controller.GetComponent<RestaurantController>().money.ToString();
			
			}
		}
	
	}

	public void StartTimer(){
	
		start = true;

	}

}
