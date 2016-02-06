using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;

	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		Vector2 movement_Vector = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if (movement_Vector != Vector2.zero) {
		
			anim.SetBool ("iswalking", true);
			anim.SetFloat("input_x", movement_Vector.x);
			anim.SetFloat("input_y", movement_Vector.y);

		} else {
		
			anim.SetBool("iswalking", false);
		
		}

		rbody.MovePosition (rbody.position + movement_Vector * Time.deltaTime);

	}
}
