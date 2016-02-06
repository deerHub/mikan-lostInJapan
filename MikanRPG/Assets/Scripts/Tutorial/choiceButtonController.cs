using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class choiceButtonController : MonoBehaviour, IPointerClickHandler {

	public ExerciseCanvasController canvas;
	public choiceButtonController other1;
	public choiceButtonController other2;
	public choiceButtonController other3;
	public nextQuestionController nxtQ;
	public Text text;
	private Animator anim;
	public char choiceType;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		text.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		text.text = TutorialStaticVariables.getChoice (choiceType);
	}

	public void OnPointerClick (PointerEventData eventData){
		if (canvas.answerQuestion (text.text)) {
			anim.SetBool("correct", true);
			anim.SetBool("answered", true);

			TutorialStaticVariables.incrementQuestionsAnswered();

<<<<<<< HEAD
			GameObject.Find("CorrectSoundEffect").GetComponent<AudioSource>().Play();
=======
			//GameObject.Find("CorrectSoundEffect").GetComponent<AudioSource>().Play();
>>>>>>> origin/master

			prepareNextQuestion();
			

		} else {
			GameObject.Find("WrongSoundEffect").GetComponent<AudioSource>().Play();
			anim.SetBool("correct", false);
			anim.SetBool("answered", true);

		}


	}

	public void btnActivate(){
		anim.SetBool ("answered", false);
		//gameObject.SetActive (true);
	}

	public void prepareNextQuestion(){
		other1.gameObject.SetActive (false);
		other2.gameObject.SetActive (false);
		other3.gameObject.SetActive (false);

		nxtQ.gameObject.SetActive (true);
	}
	
}
