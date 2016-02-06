using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomerLifeLeftController : MonoBehaviour {

	private Text scoreText;
	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
		scoreText.text = "" + RestaurantGlobals.getScore ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "" + RestaurantGlobals.getScore ();
	}
}
