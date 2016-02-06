using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ProfileList {

	public List<Game> savedGames = new List<Game>();
	public string latestGame;

	public ProfileList(){
	}

}
