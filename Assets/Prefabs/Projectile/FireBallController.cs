using UnityEngine;
using System.Collections;

public class FireBallController : MonoBehaviour {

	public float damage = 10f;
	public float speed = 5f;

	private bool hit = false;
	private float direction;
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
		rigidbody2D.velocity = new Vector2 (speed * direction, rigidbody2D.velocity.y);
	}
}
