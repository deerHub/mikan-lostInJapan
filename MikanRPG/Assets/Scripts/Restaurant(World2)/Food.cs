using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Food : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	public Transform parentToReturnTo = null;
	public Transform parentBefore = null;

	public enum FoodType
	{
		GOHAN, MENRUI, SAKANA, SUSHI, OCHA
	}

	public FoodType type = FoodType.GOHAN;

	public void OnBeginDrag(PointerEventData eventData){

		parentToReturnTo = this.transform.parent;
		parentBefore = this.transform.parent;
		this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}
	
	public void OnDrag(PointerEventData eventData){

		this.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData){

		this.transform.SetParent (parentToReturnTo);
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

}