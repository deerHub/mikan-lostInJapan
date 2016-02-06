using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using UnityEngine.EventSystems; 

public class Table : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	private Food.FoodType type;

	private Food foodServed;

	public Image orderCallout;
	public Image checkOrNot;
	public Transform controller;
	string checkImage = "check";
	private string errorImage = "error";

	void Start(){

		orderCallout = orderCallout.GetComponent<Image> ();
		checkOrNot = checkOrNot.GetComponent<Image> ();
		controller = controller.GetComponent<Transform> ();
		checkOrNot.enabled = false;

		if (orderCallout != null)
			NewOrder ();
	
	}

	void Update(){
	}

	public void OnPointerEnter(PointerEventData eventData){
	}

	public void OnPointerExit(PointerEventData eventData){
	}

	public void OnDrop(PointerEventData eventData){

		foodServed = eventData.pointerDrag.GetComponent<Food> ();

		if (foodServed != null) {

			foodServed.parentToReturnTo = this.transform;

			CheckAnswer(foodServed);

		}

	}

	private void CheckAnswer(Food food){

		if(type == food.type){
			if(checkImage != ""){
				checkOrNot.sprite = Resources.Load<Sprite>("check");
				controller.GetComponent<RestaurantController>().money += 100;
				controller.GetComponent<RestaurantController>().earnings.text = controller.GetComponent<RestaurantController>().money.ToString();
			}
		}else{
			if(errorImage != ""){
				checkOrNot.sprite = Resources.Load<Sprite>("error");
			}
		}
		checkOrNot.enabled = true;
		StartCoroutine (WaitForAFewSeconds());
	
	}

	private void NewOrder(){

		var values = Enum.GetValues (typeof(Food.FoodType));
		type = (Food.FoodType)values.GetValue(UnityEngine.Random.Range(0,values.Length));
	
		orderCallout.GetComponentInChildren<Text>().text = this.type.ToString();
		orderCallout.GetComponentInChildren<Text>().enabled = true;
		orderCallout.enabled = true;
		gameObject.GetComponentInChildren<RandomCustomer> ().person.enabled = true;
		gameObject.GetComponentInChildren<RandomCustomer> ().LoadSprite ("People");

	}

	IEnumerator WaitForAFewSeconds(){
	
		yield return new WaitForSeconds(UnityEngine.Random.Range(1,3));
		checkOrNot.enabled = false;
		orderCallout.GetComponentInChildren<Text>().enabled = false;
		orderCallout.enabled = false;
		gameObject.GetComponentInChildren<RandomCustomer> ().person.enabled = false;
		gameObject.GetComponentInChildren<Food> ().transform.SetParent (foodServed.parentBefore);
		yield return new WaitForSeconds(UnityEngine.Random.Range(3,6));
		NewOrder ();
	
	}
}
