<<<<<<< HEAD
using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> origin/master
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class ItemCardController : MonoBehaviour {

	public ItemController []items;
	public Text quantity;

	private string answerName;
	private int answerNum;


	public Text textName;
	public Text textNum;

	public ShopCustomerNumController customerNum;
	public ShopLifeController lifeNum;

	private Animator anim;
	private bool available;
	private float delay;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		delay = 1;
		anim.SetBool ("isAvailable", false);
		available = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (available == false) {

			delay -= Time.deltaTime;
			if(delay < 0){
				generateQuestion();
				delay = 2;
				available = true;
				anim.SetBool ("isAvailable", true);
				anim.SetBool ("hasAnswered", false);
			}
		}
	}



	public void answer(){
<<<<<<< HEAD
		if (available == true && ShopGlobals.running) {
			if (ItemSelectedController.getSelectedItem ().getText () == answerName ) {
				if(ShopEndController.instance.gameHasNumbers){
					if(answerNum == int.Parse (quantity.text)){
						ShopSounds1.instance.playSound("win");
					}
					else{
						lifeNum.reduceScore();
					}
				}
				else{
					ShopSounds1.instance.playSound("win");
				}


			} else {

=======
		if (available == true) {
			if (ItemSelectedController.getSelectedItem ().getText () == answerName && answerNum == int.Parse (quantity.text)) {
				ShopSounds1.instance.playSound("win");

			} else {
				ShopSounds1.instance.playSound("fail");
>>>>>>> origin/master
				lifeNum.reduceScore();
			}


			customerNum.reduceCustomers();
	
			anim.SetBool ("isAvailable", false);
			anim.SetBool ("hasAnswered", true);
			available = false;
		}
	}

	public void generateQuestion(){
		answerName = randomItem ();
		answerNum = Random.Range (1, 10);
		textName.text = JapaneseTranslator.translate (answerName);
<<<<<<< HEAD

		if (ShopEndController.instance.gameHasNumbers) {
			textNum.text = "" + JapaneseTranslator.number (answerNum);
		}
=======
		textNum.text = "" + JapaneseTranslator.number (answerNum);
>>>>>>> origin/master

	}

	string randomItem(){
		int num = Random.Range (0, items.Length -1);

		return items [num].getText();
	}




}
