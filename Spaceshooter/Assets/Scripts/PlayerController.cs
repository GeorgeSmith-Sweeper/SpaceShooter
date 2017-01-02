using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Serializable makes the fields visable inside the of Unity GUI
[System.Serializable]

public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;

	// grabs the ridgidbody of the spaceship
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	// handles the shots in front of the ship.
	void Update () 
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
		}
	}

	void FixedUpdate ()
	{   
		// grabs the arrow keys input from the user
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// handles the ships movement and speed 
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		// handles the boundarys of the game board
		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		// handles the tilt of the ship
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt); 
	}
}
