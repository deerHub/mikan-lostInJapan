using UnityEngine;
using System.Collections;

public class WarpToScene : MonoBehaviour {

	public int sceneNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		Application.LoadLevel (sceneNumber);
	}

	public void ClickToScene(){
		Application.LoadLevel (sceneNumber);
	}
}
