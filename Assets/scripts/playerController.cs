using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float maxSpeed;
	Rigidbody2D myRB;
	Animator theAnimator;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>();
		theAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis("Horizontal");
		theAnimator.SetFloat("speed", move);
		myRB.velocity = new Vector2(move*maxSpeed, myRB.velocity.y);
		
	}
	
}
