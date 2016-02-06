using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExerciseCanvasController : MonoBehaviour {

	public TutorialExerciseQuestion[] questions;
	private int indxQuestion;

	private static int val;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void askAQuestion(){


		if (questions.Length > 0) {
			indxQuestion = Random.Range(0, questions.Length -1);
			TutorialStaticVariables.setEverything(questions[indxQuestion]);
		
		}

	}

	public bool answerQuestion(string str){
		bool ret = false;
		if (isValidIndex (indxQuestion)) {
			ret = questions[indxQuestion].isAnswerCorrect(str);
		}
		return ret;
	}

	private bool isValidIndex(int n){
		bool ret = false;

		if (n >= 0 && n < questions.Length) {
			ret = true;
		}

		return ret;
	}
}
