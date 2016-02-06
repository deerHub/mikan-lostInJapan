using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Events;
using System.IO;


public class RandomCustomer : MonoBehaviour {

	public Sprite[] sprites;
	public string resourceName;
	public int currentSprite = -1;
	public Image person;

	// Use this for initialization
	void Start () {

		person = gameObject.GetComponent<Image> ();

		if(resourceName != ""){

			LoadSprite(resourceName);

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadSprite(string resourceName){

		sprites = Resources.LoadAll<Sprite>(resourceName);
		
		person.sprite = sprites[Random.Range(0, sprites.Length)];

	}
}
