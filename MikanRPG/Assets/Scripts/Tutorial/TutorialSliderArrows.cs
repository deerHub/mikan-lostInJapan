using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TutorialSliderArrows : MonoBehaviour, IPointerClickHandler {

	public Animator anim;
	public TutorialCanvasController canvas;
	public TutorialSliderArrows otherArrow;
	public bool isleft;

	void Start () {
		anim.SetBool ("enable", true);

		updateMe ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enableButton(bool enabled){
		//anim.SetBool ("enable", enabled);
	}

	public void OnPointerClick (PointerEventData eventData){
		if (isleft) {
			canvas.goPrev();
			anim.SetBool("enable", !canvas.isMin());
		} else {
			canvas.goNext();
			anim.SetBool("enable", !canvas.isMax());
		}

		otherArrow.updateMe ();

	}

	public void updateMe(){
		if (isleft) {
			anim.SetBool("enable", !canvas.isMin());
		} else {
			anim.SetBool("enable", !canvas.isMax());
		}
	}
	                                  


}
