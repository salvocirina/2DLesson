using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rb;
	private float speedMov = 5.0f;
	private bool facingRight;
	public LayerMask lm;


	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		facingRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveH = Input.GetAxis ("Horizontal");

		if (Input.GetKeyDown (KeyCode.D) && facingRight)
			transform.localScale = new Vector2 (transform.localScale.x, transform.localScale.y);
		else if (Input.GetKeyDown (KeyCode.D) && !facingRight) {
			transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
			facingRight = true;
		}
		else if (Input.GetKeyDown (KeyCode.A) && !facingRight)
			transform.localScale = new Vector2 (transform.localScale.x, transform.localScale.y);
		else if (Input.GetKeyDown (KeyCode.A) && facingRight) {
			transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
			facingRight = false;
		}
		 

		Move (moveH);

		anim.SetFloat ("Speed", moveH);
	}


	void Move(float MoveH) {
		rb.velocity = new Vector2(MoveH * speedMov , 0);
	}
}
