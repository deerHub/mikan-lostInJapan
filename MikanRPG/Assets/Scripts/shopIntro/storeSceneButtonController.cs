using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class storeSceneButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerEnter (PointerEventData eventData){
		anim.SetBool ("isHovered", true);
	}

	public void OnPointerExit (PointerEventData eventData){
		anim.SetBool ("isHovered", false);
	}

	public void OnPointerClick (PointerEventData eventData){
		anim.SetBool ("isClicked", true);
	}

	public void unClick(){
		anim.SetBool ("isClicked", false);
	}
}
