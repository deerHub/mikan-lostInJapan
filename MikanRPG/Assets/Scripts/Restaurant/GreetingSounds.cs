using UnityEngine;
using System.Collections;

public class GreetingSounds : SoundCollection {

	public static GreetingSounds instance;
	
	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy(this);
		}

	}


}
