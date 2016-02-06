using UnityEngine;
using System.Collections;

public class RestaurantGlobals : MonoBehaviour {

	private static int Day = 1;
	private static int score = 7;
	private static bool dragging = false;
	private static GreetingButtonController button = null;

	public static bool stop = false;

	public static bool isDragging(){
		return dragging;
	}

	public static void setDragging(bool drag){
		dragging = drag;
	}

	public static int getDay(){
		return Day;
	}

	public static void incrementDay(){
		Day++;
		if (Day > 3) {
			EndingDialogContoller.instance.gameOver(score);
		}
	}

	public static void setDay(int num){
		Day = num;
	}

	public static void setScore(){
		score = 7;
	}

	public static void reduceScore(){
		score--;

		if (score <= 0) {
			EndingDialogContoller.instance.gameOver(score);
		}
	}

	public static int getScore(){
		return score;
	}

	public static void setGreetingButton(GreetingButtonController btn){
			button = btn;
	}

	public static void unsetGreetingButton(){
		try{
			button.stopDrag();
		}catch(System.NullReferenceException ex){

		}
		button = null;
	}

}
