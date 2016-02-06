using UnityEngine;

using System.Collections;
using UnityEngine.EventSystems; 

public class ServerTable : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData){
	}
	
	public void OnPointerExit(PointerEventData eventData){
	}
	
	public void OnDrop(PointerEventData eventData){
		
		Food foodServed = eventData.pointerDrag.GetComponent<Food> ();
		
		if (foodServed != null) {
			
			foodServed.parentToReturnTo = this.transform;
			
		}
		
	}
}
