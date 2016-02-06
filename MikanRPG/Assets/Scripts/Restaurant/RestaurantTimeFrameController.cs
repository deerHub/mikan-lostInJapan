using UnityEngine;
using System.Collections;

public class RestaurantTimeFrameController : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetInteger ("day", RestaurantGlobals.getDay());

	}
}
