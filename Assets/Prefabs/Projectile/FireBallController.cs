using UnityEngine;
using System.Collections;

public class FireBallController : MonoBehaviour {

	public float damage = 10f;
	public float speed = 5f;

	private bool hit = false;
	private float direction;

	public Animator anim;
	// Use this for initialization
	void Start () {
		direction = GameObject.Find("Player").GetComponent<PlayerControls>().GetFacingDirection();

		if (direction < 0) {
			Vector3 theScale = transform.localScale;
			theScale.x *= direction;
			transform.localScale = theScale;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(hit)
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
		else
			rigidbody2D.velocity = new Vector2 (speed * direction, rigidbody2D.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other) {
		hit = true;
		collider2D.enabled = false;
		anim.SetTrigger ("hit");
	}

	void Destroy(){
		Destroy(this.gameObject);
	}
}
