using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopCustomerNumController : MonoBehaviour {

	public int customerNum;
	public ShopLifeController lifeNum;
	private Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();

		if (customerNum < 0) {
			customerNum = 1;
		}

		text.text = "" + customerNum;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void reduceCustomers(){
		customerNum--;
		text.text = "" + customerNum;
<<<<<<< HEAD
		if (customerNum <= 0) {
			ShopEndController.instance.gameOver(ShopGlobals.score);
		}
=======
>>>>>>> origin/master
	}
}
