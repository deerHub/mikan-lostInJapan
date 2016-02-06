using UnityEngine;
using System.Collections;

public class CustomerController : MonoBehaviour {


	public RuntimeAnimatorController[] animControllers;


	public Vector3 otherPosition;
	public Collider2D trigger1;
	public Collider2D trigger2;
	public Collider2D lineCollider;
	public Collider2D btnOhayou;
	public Collider2D btnKonnichiwa;
	public Collider2D btnKonwbanwa;
	public Collider2D btnArigatou;


	private Vector3 currentPosition;
	private Vector3 targetPosition;
	private Animator anim;
	public Animator stateAnim;

	private bool moving;
	private float timeToMove;
	private bool isDown;
	private bool walking;
	private int direction;

	private int moveSpeed;
	private Rigidbody2D rigidBody;
	private Collider2D apprGreeting; // appropriate greeting
	private bool isGreeted;
	private Sprite sprite;


	private bool stop;

	// Use this for initialization
	void Start () {
		stop = false;
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody2D> ();
	


		setAnimation ();

		stateAnim.SetBool ("isCorrect", true);
		stateAnim.SetBool ("isGreeted", false);
	

		normalState ();
		timeToMove = Random.Range (2, 5);

		currentPosition = this.transform.position;
		moveSpeed = 30;
		direction = 1;

		rigidBody.velocity = Vector2.zero;

		isGreeted = false;
		apprGreeting = btnOhayou;

	}
	
	// Update is called once per frame
	void Update () {

		if (RestaurantGlobals.stop == false) {
			if (moving == false) {
				timeToMove -= Time.deltaTime;

				moveSpeed = Random.Range (30, 50);

				int n = Random.Range (1, 7);

				if (n % 5 == 0) {
					moveSpeed = 100;
				}


				if (timeToMove < 0f) {
					isDown = decideMovement ();
					walking = true;
					moving = true;
					isGreeted = false;
					rigidBody.velocity = new Vector2 (0f, direction * moveSpeed);
					normalState ();
				}
			} else {

				//transform.Translate (new Vector3 (0f, direction * 2 * (int)(Time.deltaTime), 0f));
		
			}
		} else {
			rigidBody.velocity = new Vector2 (0f, 0f);
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			Debug.Log("Stopped");
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		Debug.Log (gameObject.name + " is triggered");

		if (RestaurantGlobals.isDragging () == false) {
			RestaurantGlobals.unsetGreetingButton();
			GreetingSounds.instance.playSound(other.name);

			if (other.gameObject.name == trigger1.name || other.gameObject.name == trigger2.name) {
				moving = false;
				transform.Translate (new Vector3 (0f, 0f, 0f));
				rigidBody.velocity = Vector2.zero;
				timeToMove = Random.Range (2, 5);
				setAnimation ();
				Debug.Log (gameObject.name + " is restarting.");
			} else if (isGreeted == false) {

				if (other.name == lineCollider.name) {
					errorGreetingState ();
					isGreeted = true;
				} else {
					isGreeted = true;
					Debug.Log (correctGreeting ());
					if (other.name == correctGreeting ()) {
					
						correctGreetingState ();
					} else {
						errorGreetingState ();
					}


				}


			}
		}
	}


	bool decideMovement(){
		bool retval = true;
		int x;

		transform.Translate (new Vector3 (0f, 0f, 0f));

		x = Random.Range (1, 20);



		if (x % 2 == 0) {
			retval = false;
			transform.position = new Vector3(currentPosition.x, otherPosition.y, transform.position.z);
			direction = 1;
		} else {
			transform.position = new Vector3(currentPosition.x, currentPosition.y, transform.position.z);
			direction = -1;
		}

		anim.SetBool ("isDown", retval);
		return retval;
	}

	void setAnimation(){
		int arraySize = animControllers.Length;
		int randNum;

		randNum = Random.Range (0, arraySize-1);

		anim.runtimeAnimatorController = animControllers[randNum];
		anim.SetBool ("isDown", false);

	}

	void correctGreetingState(){
		stateAnim.SetBool ("isCorrect", true);
		stateAnim.SetBool ("isGreeted", true);
		GreetingSounds.instance.playSound ("win");
	}

	void errorGreetingState(){
		stateAnim.SetBool ("isCorrect", false);
		stateAnim.SetBool ("isGreeted", true);
		GreetingSounds.instance.playSound ("fail");
		RestaurantGlobals.reduceScore ();
	}

	void normalState(){
		stateAnim.SetBool ("isGreeted", false);
	}

	string correctGreeting(){
		string retval;

		if (direction == 1) {
			retval = btnArigatou.name;
		} else {
			int day = RestaurantGlobals.getDay();

			if(day == 1){
				retval = btnOhayou.name;
			}
			else if(day == 2){
				retval = btnKonnichiwa.name;
			}
			else{
				retval = btnKonwbanwa.name;
			}
		}

		return retval;
	}





}
