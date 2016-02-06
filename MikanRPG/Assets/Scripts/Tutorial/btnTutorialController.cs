using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class btnTutorialController : MonoBehaviour, IPointerClickHandler {

	public TutorialCanvasController canvasTutorial;
	public ExerciseCanvasController exerTutorial;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerClick (PointerEventData eventData){
		exerTutorial.gameObject.SetActive (false);
		canvasTutorial.gameObject.SetActive (true);
		
	}
}
