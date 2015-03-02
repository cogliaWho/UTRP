using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	private bool facingRight = true;
	public float fastShootCooldown = 0.4f;

	public Transform groundCheck;
	public LayerMask whatIsGround;

	//grounded stuff
	bool grounded = false;
	bool doubleJump = false;
	float groundRadius = 0.1f;

	//shoot
	bool isShooting = false;
	float nextShoot;
	public GameObject fireBall;
	public Transform shotSpawn;

	Animator anim;
	
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		if (grounded)
			doubleJump = false;

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(move));

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if(move < 0 && facingRight)
			Flip ();
	}

	void Update (){
		if((grounded || !doubleJump) && Input.GetButtonDown("Jump"))
		{
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));

			if(!doubleJump && !grounded){
				doubleJump = true;
				anim.SetTrigger("DoubleJump");
			}
		}

		if (grounded && (Time.time > nextShoot) && Input.GetButtonDown ("Fire1")) {
			nextShoot = Time.time + fastShootCooldown;
			anim.SetTrigger("FastShoot");
		} 
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void ShootFastShoot(){
		GameObject fireBallClone = Instantiate(fireBall, shotSpawn.position, shotSpawn.rotation) as GameObject;
	}

	public float GetFacingDirection(){
		if (facingRight)
			return 1f;
		else
			return -1f;
	}
}
