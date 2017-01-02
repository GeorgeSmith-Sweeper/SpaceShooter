using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		// returns control back to Unity's game loop
		if (other.tag == "Boundary") {
			return;
		}
		//destroys the bolt, and the asteroid once they come in contact with each other
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
