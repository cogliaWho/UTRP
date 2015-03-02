using UnityEngine;
using System.Collections;

public class RobotBehaviour : MonoBehaviour {

	public float health = 20f;
	public float speed = 3f;
	public float MaxDist = 10f;
	public float MinWalkDist = 5f; 
	public Animator anim;

	private float targetL;
	private float targetR;
	private float direction;
	private float currentPosition;
	private Transform player;
	public bool facingLeft;
	private bool isMoving = true;

	void Start(){
		targetL = transform.position.x - (MinWalkDist / 2);
		targetR = transform.position.x + (MinWalkDist / 2);
		facingLeft = true;
		StartMove ();
		Debug.Log ("targetL " + targetL);
		Debug.Log ("targetR " + targetR);
		Debug.Log ("currentPosition " + transform.position.x);
	}

	// Update is called once per frame
	void Update () {
		player = GameObject.Find ("Player").transform;
		currentPosition = transform.position.x;

		if(isMoving){
			if (currentPosition <= targetL && facingLeft) {
				facingLeft = false;
				isMoving = false;
				anim.SetBool ("turn", true);
				anim.SetBool ("walk", false);
			} else if (currentPosition >= targetR && !facingLeft) {
				facingLeft = true;
				isMoving = false;
				anim.SetBool ("turn", true);
				anim.SetBool ("walk", false);
			}

			if (currentPosition > targetL && facingLeft)
				MoveLeft ();
			if (currentPosition < targetR && !facingLeft)
				MoveRight ();


			anim.SetBool ("walk", true);
		}
	}
	
	public void MoveLeft(){
		direction = -1f;
		facingLeft = true;
		rigidbody2D.AddForce(new Vector2 (direction * speed, rigidbody2D.velocity.y) - rigidbody2D.velocity, ForceMode2D.Force);
	}

	public void MoveRight(){
		direction = 1f;
		facingLeft = false;
		rigidbody2D.AddForce(new Vector2 (direction * speed, rigidbody2D.velocity.y) - rigidbody2D.velocity, ForceMode2D.Force);
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("other.bounds.size.x " + other.bounds.size.x);
	}

	public void StartMove(){
		Vector3 theScale = transform.localScale;
		if(theScale.x > 0 && !isMoving)
			Flip(theScale);
		if(theScale.x < 0 && !isMoving)
			Flip(theScale);
		anim.SetBool ("turn", false);
		isMoving = true;
	}

	public void Flip(Vector3 theLocalScale){
		transform.localScale = new Vector3(theLocalScale.x *= -1, theLocalScale.y, theLocalScale.z);
	}
}
