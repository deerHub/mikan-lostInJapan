using UnityEngine;
using System.Collections;

public class TutorialStaticVariables : MonoBehaviour {

	private static string questionText = "";
	private static string choiceA = "";
	private static string choiceB = "";
	private static string choiceC = "";
	private static string choiceD = "";
	public static int questionsAnswered = 0;

	public static string getChoice(char choice){
		string ret = "";

		switch (choice) {
			case 'A':
			case 'a': ret = choiceA; break;
			case 'B':
			case 'b': ret = choiceB; break;
			case 'C':
			case 'c': ret = choiceC; break;
			case 'D':
			case 'd': ret = choiceD; break;
		}

		return ret;
	}

	public static void setChoice(char choice, string set){
		
		switch (choice) {
		case 'A':
		case 'a': choiceA = set;  break;
		case 'B':
		case 'b': choiceB = set; break;
		case 'C':
		case 'c': choiceC = set; break;
		case 'D':
		case 'd': choiceD = set; break;
		}

		
	}

	public static string getQuestionText(){
		return questionText;
	}

	public static void clear(){
		questionText = "";
		choiceA = "";
		choiceB = "";
		choiceC = "";
		choiceD = "";
		questionsAnswered = 0;
	}

	public static void setEverything(TutorialExerciseQuestion question){
		questionText = question.question;


		string[] str = question.randomChoices ();







		choiceA = str [0];
		choiceB = str [1];
		choiceC = str [2];
		choiceD = str [3];
	}


	public static void incrementQuestionsAnswered(){
		++questionsAnswered;
	}




}
