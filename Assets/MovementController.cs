using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
	
	void StartMove () {
		this.gameObject.transform.parent.GetComponent<RobotBehaviour> ().StartMove();
	}

}
