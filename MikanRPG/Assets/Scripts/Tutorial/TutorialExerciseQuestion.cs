using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]


public class TutorialExerciseQuestion: System.Object{

	public string question;
	public string correctAnwer;
	public string falseAnswer1;
	public string falseAnswer2;
	public string falseAnswer3;
	public Sprite sprite;

	private static int val;


	public string[] randomChoices(){
		string[] choices = new string[4];

		choices [0] = correctAnwer;
		choices [1] = falseAnswer1;
		choices [2] = falseAnswer2;
		choices [3] = falseAnswer3;

		for (int i = 0; i < 20; ++i) {
			int x = Random.Range(0, 3);
			int y = Random.Range(0, 3);

			string temp = choices[x];
			choices[x] = choices[y];
			choices[y] = temp;
		}



		return choices;
	}

	public bool isAnswerCorrect(string str){
		bool ret = false;
		if (str.ToLower () == correctAnwer.ToLower ()) {
			ret = true;
		}

		return ret;
	}
}
