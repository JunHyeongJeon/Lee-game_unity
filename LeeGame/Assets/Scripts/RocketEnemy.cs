﻿using UnityEngine;
using System.Collections;

public class RocketEnemy : MonoBehaviour 
{
	public float destroyTime;
	public GameObject explosion;		// Prefab of explosion effect.
	public float DamegeMount = 10f;

	void Start () 
	{
		// Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, destroyTime);
	}


	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, transform.position, randomRotation);
	} 	
	
	void OnTriggerEnter2D (Collider2D col) 
	{
		//Debug.Log ("Collision");
		// If it hits an enemy...
		if (col.tag == "Player") {

						// ... find the Enemy script and call the Hurt function.
						col.gameObject.GetComponent<PlayerHealth> ().TakeDamage ();

						// Call the explosion instantiation.
						OnExplode ();

						// Destroy the rocket.
						Destroy (gameObject);
				} 
		else if (col.tag == "Ally") {
		
			col.gameObject.GetComponent<Ally_>().Hurt();
			// Call the explosion instantiation.
			OnExplode();
			
			// Destroy the rocket.
			Destroy (gameObject);
		}
		// Otherwise if it hits a bomb crate...
		else if(col.tag == "BombPickup")
		{
			// ... find the Bomb script and call the Explode function.
			col.gameObject.GetComponent<Bomb>().Explode();

			// Destroy the bomb crate.
			Destroy (col.transform.root.gameObject);

			// Destroy the rocket.
			Destroy (gameObject);
		}
		// Otherwise if the player manages to shoot himself...
		else if(col.gameObject.tag != "Enemy")
		{

			// Instantiate the explosion and destroy the rocket.
			OnExplode();
			Destroy (gameObject);
		}
	}
}
