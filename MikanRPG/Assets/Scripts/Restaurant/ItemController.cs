using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemController : MonoBehaviour{

	private Animator anim;
	private bool click;
	public Text text;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	

		anim.SetBool ("hover", false);
		anim.SetBool ("click", false);
		click = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		anim.SetBool ("click", true);
		ShopSounds1.instance.playSound ("click");
		ItemSelectedController.selectMe (this);
	}

	void OnMouseOver(){
		anim.SetBool ("hover", true);
	}

	void OnMouseExit(){
		anim.SetBool ("hover", false);
	}

	public void deselect(){
		anim.SetBool ("hover", false);
		anim.SetBool ("click", false);
	}

	public string getText(){
		return text.text;
	}



}
