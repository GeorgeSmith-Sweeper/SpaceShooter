using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other) {
		// returns control back to Unity's game loop
		if (other.tag == "Boundary") {
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
		//destroys the bolt, and the asteroid once they come in contact with each other
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
