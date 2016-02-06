using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class btnExerciseController : MonoBehaviour, IPointerClickHandler{

	public TutorialCanvasController canvasTutorial;
	public ExerciseCanvasController exerTutorial;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerClick (PointerEventData eventData){
		canvasTutorial.gameObject.SetActive (false);

		TutorialStaticVariables.clear ();

		exerTutorial.askAQuestion ();
		exerTutorial.gameObject.SetActive (true);

	}
}
