using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class storeScenePanelController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    
	public storeSceneButtonController btnScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerEnter (PointerEventData eventData){

	}
	
	public void OnPointerExit (PointerEventData eventData){
		btnScene.unClick ();
	}
}
