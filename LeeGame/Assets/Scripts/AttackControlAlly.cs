using UnityEngine;
using System.Collections;

public class AttackControlAlly : MonoBehaviour
{
	public Rigidbody2D rocket;				// Prefab of the rocket.

	public float speed = 20f;// The speed the rocket will fire at.
	public float Stopspeed = 2f;
	//public UISprite attack;

	private Ally_ enemy;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.


	void Awake()
	{
		// Setting up the references.
		anim = transform.root.gameObject.GetComponent<Animator>();
		enemy = transform.root.GetComponent<Ally_>();
			
	}


	void Update ()
	{
		// If the fire button is pressed...
		/*if(Input.GetButtonDown("Fire1"))
		{
			// ... set the animator Shoot trigger parameter and play the audioclip.
			anim.SetTrigger("Shoot");
			audio.Play();

			// If the player is facing right...
			if(playerCtrl.facingRight)
			{
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(-speed, 0);
			}
		}*/
	}
	public void fire(){

		if (enemy.facingright) {

						audio.Play ();
						// ... instantiate the rocket facing right and set it's velocity to the right. 
						Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
						bulletInstance.velocity = new Vector2 (-speed, 0);
				} else {

						audio.Play ();
						// Otherwise instantiate the rocket facing left and set it's velocity to the left.
						Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
						bulletInstance.velocity = new Vector2 (speed, 0);
				}

				
	}




}
