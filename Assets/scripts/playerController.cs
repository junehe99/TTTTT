using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float maxSpeed;
	Rigidbody2D myRB;
	Animator theAnimator;
	public AudioClip flipSound;
	public float flipSoundVolume;
	
	void OnTriggerEnter2D (Collider2D collider) {
		Destroy(gameObject);
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("03fail");
	}

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>();
		theAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis("Horizontal");
		theAnimator.SetFloat("speed", Mathf.Abs(move));
		myRB.velocity = new Vector2(move*maxSpeed, myRB.velocity.y);
	}

	void Update ()  {
		if (Input.GetKeyDown (KeyCode.Space)
		    || Input.GetKeyDown(KeyCode.JoystickButton0)
		    || Input.GetKeyDown(KeyCode.JoystickButton16)) {
			Debug.Log("got key down");
			myRB.gravityScale = -myRB.gravityScale;
			Vector3 scale = transform.localScale;
			scale.y *= -1;
			transform.localScale = scale;
			AudioSource.PlayClipAtPoint(flipSound, transform.position, flipSoundVolume);
		}
	}
}
