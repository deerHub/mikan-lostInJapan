using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialCanvasController : MonoBehaviour {

	public TutorialSlidePanel[] slides;
	public Text slideCounter;

	private int currentSlide;

	void Start () {
		currentSlide = -1;
		disableAll ();
		enableFirst ();


		updateSlideCounter ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void enableFirst(){

		if (slides.Length > 0) {
			slides [0].gameObject.SetActive(true);
			currentSlide = 0;
		} else {
			currentSlide = -1;
		}

	}

	void disableAll(){
		foreach (TutorialSlidePanel slide in slides) {
			slide.gameObject.SetActive(false);
		}
	}



	public void goNext(){
		if ((currentSlide + 1) < slides.Length) {
			slides[currentSlide].gameObject.SetActive(false);
			slides[++currentSlide].gameObject.SetActive (true);
		}

		updateSlideCounter ();
	}

	public void goPrev(){
		if (currentSlide > 0) {
			slides[currentSlide].gameObject.SetActive (false);
			slides[--currentSlide].gameObject.SetActive  (true);
		}

		updateSlideCounter ();
	}

	public bool isMax(){
		bool ret = true;
		
		if ((currentSlide + 1) < slides.Length) {
			ret = false;
		}
		
		return ret;
	}

	public bool isMin(){
		bool ret = true;

		if (currentSlide > 0) {
			ret = false;
		}

		return ret;
	}

	public void updateSlideCounter(){

		slideCounter.text = (currentSlide + 1) + "/" + slides.Length;
	}



}
