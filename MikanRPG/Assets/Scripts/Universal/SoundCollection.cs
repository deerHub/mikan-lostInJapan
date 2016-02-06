using UnityEngine;
using System.Collections;

public class SoundCollection : MonoBehaviour {

	public SoundBox[] sounds;

	public void playSound(string name){
		int len = sounds.Length;

		for(int i = 0; i < len; ++i){
			if(sounds[i].name == name){
				sounds[i].audio.Play();
				break;
			}
		}
	}

}
