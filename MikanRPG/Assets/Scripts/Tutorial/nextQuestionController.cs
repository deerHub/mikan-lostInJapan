using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class nextQuestionController : MonoBehaviour, IPointerClickHandler  {

	public ExerciseCanvasController canvas;
	public Text text;
	public choiceButtonController b1;
	public choiceButtonController b2;
	public choiceButtonController b3;
	public choiceButtonController b4;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerClick (PointerEventData eventData){
		canvas.askAQuestion ();
		gameObject.SetActive (false);

		activateAll (false);

		b1.btnActivate ();
		b2.btnActivate ();
		b3.btnActivate ();
		b4.btnActivate ();
	}

	public void activateAll(bool enable){
		text.gameObject.SetActive (enabled);
		b1.gameObject.SetActive (enabled);
		b2.gameObject.SetActive (enabled);
		b3.gameObject.SetActive (enabled);
		b4.gameObject.SetActive (enabled);
	}


}
