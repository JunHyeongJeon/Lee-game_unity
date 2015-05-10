using UnityEngine;
using System.Collections;

public class LeeAttackControl : MonoBehaviour
{
	public Rigidbody2D rocket;				// Prefab of the rocket.
	public Rigidbody2D runningAlly;
	public Rigidbody2D screwShape;
	public Rigidbody2D Melee;
	public float speed = 20f;// The speed the rocket will fire at.
	public float Stopspeed = 2f;
	public UISprite SkillUI1;
	public UISprite SkillUI2;
	public UISprite SkillUI3;
	public UISprite SkillUI4;
	public UISprite SkillUI5;
	public UISprite SkillUI6;
	private PlayerControl playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.
	public AudioClip[] audioclip;

	void Awake()
	{
		// Setting up the references.
		anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerControl>();
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
	IEnumerator fire(){
		if (SkillUI6.fillAmount >= 1) { 
//			audio = audioclip[0]; 
			audio.Play ();
			//new WaitForSeconds (2.0f)
						// If the player is facing right...
						if (playerCtrl.facingRight) {
								anim.SetTrigger ("Shoot");
								yield return new WaitForSeconds(0.5f);
								
								audio.Play ();
								// ... instantiate the rocket facing right and set it's velocity to the right. 
								Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance.velocity = new Vector2 (speed, 0);
						} else {
								playerCtrl.sideOfMove = 1;
								yield return new WaitForSeconds(0.05f);
								playerCtrl.sideOfMove = 0;
								anim.SetTrigger ("Shoot");

								yield return new WaitForSeconds(0.5f);

								audio.Play ();
								// Otherwise instantiate the rocket facing left and set it's velocity to the left.
								Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance.velocity = new Vector2 (speed, 0);
						}
				}
	}
	IEnumerator LeeSkill1(){ //attack up to down
		if (SkillUI1.fillAmount >= 1) {
			audio.Play ();	
					// If the player is facing right...
					if (playerCtrl.facingRight) {
						anim.SetTrigger ("LeeSkill1");
						// ... instantiate the rocket facing right and set it's velocity to the right. 
						Rigidbody2D bulletInstance = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
						bulletInstance.velocity = new Vector2 (Stopspeed, 0);
					} else {
						playerCtrl.sideOfMove = 1;
						yield return new WaitForSeconds(0.05f);
						playerCtrl.sideOfMove = 0;
						anim.SetTrigger ("LeeSkill1");
						// Otherwise instantiate the rocket facing left and set it's velocity to the left.
						Rigidbody2D bulletInstance = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
						bulletInstance.velocity = new Vector2 (Stopspeed, 0);
					}
							
				}
	}
	IEnumerator LeeSkill2(){ // attack down to up
		if (SkillUI2.fillAmount >= 1) {
			audio.Play ();	
			if (playerCtrl.facingRight) {
				anim.SetTrigger ("LeeSkill2");
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2 (Stopspeed, 0);
			}else {
				playerCtrl.sideOfMove = 1;
				yield return new WaitForSeconds(0.05f);
				playerCtrl.sideOfMove = 0;
				anim.SetTrigger ("LeeSkill2");
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2 (Stopspeed, 0);
			}
				}
	}
	IEnumerator LeeSkill3(){ // cross cutting // need long range attack
		if (SkillUI3.fillAmount >= 1) {
						anim.SetTrigger ("LeeSkill3");
			audio.Play ();
						//	yield return new WaitForSeconds (1.0f);
						if (playerCtrl.facingRight) {
								anim.SetTrigger ("LeeSkill3");
								yield return new WaitForSeconds(1.2f);
								// ... instantiate the screwShape facing right and set it's velocity to the right. 
								Rigidbody2D bulletInstance = Instantiate (screwShape, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance.velocity = new Vector2 (speed, 0);
								Rigidbody2D bulletInstance1 = Instantiate (screwShape, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance1.velocity = new Vector2 (speed, 0);

						} else {
								playerCtrl.sideOfMove = 1;
								yield return new WaitForSeconds(0.05f);
								playerCtrl.sideOfMove = 0;
								anim.SetTrigger ("LeeSkill3");
								yield return new WaitForSeconds(1.2f);
								// Otherwise instantiate the screwShape facing left and set it's velocity to the left.
								Rigidbody2D bulletInstance = Instantiate (screwShape, transform.position, Quaternion.Euler (new Vector3 (0, 0, -0))) as Rigidbody2D;
								bulletInstance.velocity = new Vector2 (speed, 0);
								Rigidbody2D bulletInstance1 = Instantiate (screwShape, transform.position, Quaternion.Euler (new Vector3 (0, 0, -0))) as Rigidbody2D;
								bulletInstance1.velocity = new Vector2 (speed, 0);
						}
				}
	}
	IEnumerator LeeSkill4(){ // appear running ally // need long range attack
				//	yield return new WaitForSeconds (1.0f);
				if (SkillUI4.fillAmount >= 1) {
			audio.Play ();	
						if (playerCtrl.facingRight) {
								anim.SetTrigger ("LeeSkill4");
								yield return new WaitForSeconds(1.55f);
								// ... instantiate the runningAlly facing right and set it's velocity to the right. 
								Rigidbody2D bulletInstance = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);
								Rigidbody2D bulletInstance1 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance1.velocity = new Vector2 (speed, 0);				yield return new WaitForSeconds(0.2f);	
								Rigidbody2D bulletInstance2 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance2.velocity = new Vector2 (speed, 0);				yield return new WaitForSeconds(0.2f);	
								Rigidbody2D bulletInstance3 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance3.velocity = new Vector2 (speed, 0);				yield return new WaitForSeconds(0.2f);	
								Rigidbody2D bulletInstance4 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance4.velocity = new Vector2 (speed, 0);				yield return new WaitForSeconds(0.2f);	
								Rigidbody2D bulletInstance5= Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance5.velocity = new Vector2 (speed, 0);
								Rigidbody2D bulletInstance6 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance6.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);
								Rigidbody2D bulletInstance7 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance7.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);
								Rigidbody2D bulletInstance8 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance8.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);
								Rigidbody2D bulletInstance9 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance9.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);
								Rigidbody2D bulletInstance10 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance10.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);
								Rigidbody2D bulletInstance11 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance11.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);





						} else {
								playerCtrl.sideOfMove = 1;
								yield return new WaitForSeconds(0.05f);
								playerCtrl.sideOfMove = 0;
								anim.SetTrigger ("LeeSkill4");
								yield return new WaitForSeconds(1.55f);
								// Otherwise instantiate the runningAlly facing left and set it's velocity to the left.
								Rigidbody2D bulletInstance = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);
								Rigidbody2D bulletInstance1 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance1.velocity = new Vector2 (speed, 0);				yield return new WaitForSeconds(0.2f);	
								Rigidbody2D bulletInstance2 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance2.velocity = new Vector2 (speed, 0);				yield return new WaitForSeconds(0.2f);	
								Rigidbody2D bulletInstance3 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance3.velocity = new Vector2 (speed, 0);				yield return new WaitForSeconds(0.2f);	
								Rigidbody2D bulletInstance4 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance4.velocity = new Vector2 (speed, 0);				yield return new WaitForSeconds(0.2f);	
								Rigidbody2D bulletInstance5= Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance5.velocity = new Vector2 (speed, 0);
								Rigidbody2D bulletInstance6 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance6.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);
								Rigidbody2D bulletInstance7 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance7.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);
								Rigidbody2D bulletInstance8 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance8.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);
								Rigidbody2D bulletInstance9 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance9.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);
								Rigidbody2D bulletInstance10 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance10.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);
								Rigidbody2D bulletInstance11 = Instantiate (runningAlly, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
								bulletInstance11.velocity = new Vector2 (speed, 0);yield return new WaitForSeconds(0.2f);

						}
				}
		}
	IEnumerator LeeSkill5(){ // screw attack
				if (SkillUI5.fillAmount >= 1) {
			audio.Play ();	
			if (playerCtrl.facingRight) {
				anim.SetTrigger ("LeeSkill5");
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance1 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance1.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance2 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance2.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance3 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance3.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance4 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance4.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance5 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance5.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance6 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance6.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance7 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance7.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance8 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance8.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);

			} else {
				playerCtrl.sideOfMove = 1;
				yield return new WaitForSeconds(0.05f);
				playerCtrl.sideOfMove = 0;
				anim.SetTrigger ("LeeSkill5");
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance1 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance1.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance2 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance2.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance3 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance3.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance4 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance4.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance5 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance5.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance6 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance6.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance7 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance7.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);
				Rigidbody2D bulletInstance8 = Instantiate (Melee, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance8.velocity = new Vector2 (Stopspeed, 0);
				yield return new WaitForSeconds(0.1f);

			}
				}
		}



}
