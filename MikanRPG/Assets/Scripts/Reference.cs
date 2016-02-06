using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Reference : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler {
	
	public GameObject actualButton;
	private Animator anim;
	private Vector3 originPos;
	// Use this for initialization
	void Start () {
		anim = actualButton.GetComponent<Animator> ();
		originPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnPointerDown (PointerEventData eventData){
		anim.SetBool ("isPressed", true);
	}
	
	public void OnPointerUp (PointerEventData eventData){
		anim.SetBool ("isPressed", false);
	}
	
	public void OnBeginDrag(PointerEventData eventData){
		
	}
	
	public void OnDrag(PointerEventData eventData){
		Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		point.z = gameObject.transform.position.z;
		transform.position = point;
		
		anim.SetBool ("isPressed", true);
	}
	
	public void OnEndDrag(PointerEventData eventData){
		anim.SetBool ("isPressed", false);
		transform.position = originPos;
	}
	
	public void returnToOriginalPosition(){
		anim.SetBool ("isPressed", false);
		transform.position = originPos;
	}
	
	
}
