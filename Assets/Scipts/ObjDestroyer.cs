using UnityEngine;
using System.Collections;

public class ObjDestroyer : MonoBehaviour {

	public float lifetime = 2f;

	// Use this for initialization
	void Awake () {
		Destroy (this.gameObject, lifetime); 
	}

}
