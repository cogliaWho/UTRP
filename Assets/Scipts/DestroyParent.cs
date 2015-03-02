using UnityEngine;
using System.Collections;

public class DestroyParent : MonoBehaviour {

	public void Destroy(){
		Destroy (this.gameObject.transform.parent.gameObject);
	}
}
