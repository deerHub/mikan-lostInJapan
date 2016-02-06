using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {

	public void changeToScene(int scene){
		Application.LoadLevel (scene);
	}
}
