using UnityEngine;
using System.Collections;

public class ShopSounds1 : SoundCollection {

	public static ShopSounds1 instance;
	
	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy(this);
		}
		
	}
}
