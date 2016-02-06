using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GreetingButtonController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler {

	public GameObject actualButton;
	private Animator anim;
	private Vector3 originPos;
	private bool drag = false;
	// Use this for initialization
	void Start () {
		anim = actualButton.GetComponent<Animator> ();
		originPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnPointerDown (PointerEventData eventData){
		//anim.SetBool ("isPressed", true);
	}

	public void OnPointerUp (PointerEventData eventData){
		//anim.SetBool ("isPressed", false);
	}

	public void OnBeginDrag(PointerEventData eventData){
		//RestaurantGlobals.setDragging (true);
		RestaurantGlobals.setGreetingButton (this);
		drag = true;
	}
	
	public void OnDrag(PointerEventData eventData){
		if (drag == true && RestaurantGlobals.stop == false) {
			Vector3 point = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			point.z = gameObject.transform.position.z;
			transform.position = point;
		} else {
			OnEndDrag(eventData);
		}
		//anim.SetBool ("isPressed", true);
	}
	
	public void OnEndDrag(PointerEventData eventData){
		//anim.SetBool ("isPressed", false);
		//RestaurantGlobals.setDragging (false);
		drag = false;
		returnToOriginalPosition ();
	}

	public void returnToOriginalPosition(){
		//anim.SetBool ("isPressed", false);
		transform.position = originPos;
	}

	public void stopDrag(){
		drag = false;
	}




}
