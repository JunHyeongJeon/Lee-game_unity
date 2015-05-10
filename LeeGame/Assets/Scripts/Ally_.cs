using UnityEngine;
using System.Collections;

public class Ally_ : MonoBehaviour
{
	public float realmoveSpeed = 3f;
	private float moveSpeed = 3f;		// The speed the enemy moves at.
	public int HP = 2;					// How many times the enemy can be hit before it dies.
	public Sprite deadEnemy;			// A sprite of the enemy when it's dead.
	public Sprite damagedEnemy;			// An optional sprite of the enemy when it's damaged.
	public AudioClip[] deathClips;		// An array of audioclips that can play when the enemy dies.
	public GameObject hundredPointsUI;	// A prefab of 100 that appears when the enemy dies.
	public float deathSpinMin = -100f;			// A value to give the minimum amount of Torque when dying
	public float deathSpinMax = 100f;			// A value to give the maximum amount of Torque when dying
	//public Animator anim;
	public bool facingright = false;

	private Ally_ ally;	

	public AttackControlAlly attackcontrol;

	private string targetTag = "Enemy";
	private Transform target;
	private Transform closestEnemy = null;
	private Vector3 objectPos;
	private float dist;

	private Transform allyPos;	
	//private Transform Ally;
	// 몬스터의 위치
	private Transform trMonster;
	// 유저의 위치
	//public object trPlayer;	
	// 적군과 아군 사이의 일정 거리가 되면 공격해오는 거리

	private enum ENEMYSTATE
	{
		//ENEMYTRACE,
		ENEMYATTACK,
		ENEMYRUN,
		ENEMYHURT,
		//ENEMYSPECIALATTACK,
		ENEMYDEATH
	}
	public Animator animator;
	ENEMYSTATE state = ENEMYSTATE.ENEMYRUN;

	public float fAttackDist = 20.0f;
	public Vector3 targetDir;

	private SpriteRenderer ren;			// Reference to the sprite renderer.
	private Transform frontCheck;		// Reference to the position of the gameobject used for checking if something is in front.
	private bool dead = false;			// Whether or not the enemy is dead.
	private Score score;				// Reference to the Score script.
	private Animator anim;
	bool flag = false;


	void Awake()
	{
		// Setting up the references.
		ren = transform.Find("body").GetComponent<SpriteRenderer>();
		frontCheck = transform.Find("frontCheck").transform;
		score = GameObject.Find("Score").GetComponent<Score>();
		moveSpeed = realmoveSpeed; 

	}
	void Start(){
		InvokeRepeating("getClosestEnemy", 0, 0.5f);
	}
	void Update(){

		if (target != null)
		{
			targetDir =  transform.position - target.position;

			//shootTimeLeft = Time.time - startTime;
			state = ENEMYSTATE.ENEMYATTACK;
			//Debug.Log(targetDir);
			animator.SetTrigger ("Attack");
			moveSpeed = 0.0f;
			if(flag){
				attackcontrol.fire();
				flag = !flag;
			}
			//Debug.DrawLine(transform.position, target.position, Color.yellow);
		}
		/*
		allyPos = GameObject.FindGameObjectWithTag ("Ally").transform;
		trMonster = this.gameObject.GetComponent<Transform> ();

		// 적이 죽지 않으면 스테이트 검사를 진행한다.
		float _fDist = trMonster.position.x - allyPos.position.x;
		// 적이 사정거리에 들어옴
		if ((_fDist < fAttackDist && _fDist > 0)) {
				state = ENEMYSTATE.ENEMYATTACK;
				animator.SetTrigger ("Attack");
				moveSpeed = 0.0f;
		} else {
				state = ENEMYSTATE.ENEMYRUN;
				animator.SetTrigger ("Run");
				moveSpeed = realmoveSpeed; 
		}
*/
				
	}

	void FixedUpdate ()
	{
		// Create an array of all the colliders in front of the enemy.
		Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, 1);

		// Check each of the colliders.
		foreach(Collider2D c in frontHits)
		{
			// If any of the colliders is an Obstacle...
			if(c.tag == "Obstacle")
			{
				// ... Flip the enemy and stop checking the other colliders.
				Flip ();
				break;
			}
		}

		// Set the enemy's velocity to moveSpeed in the x direction.
		rigidbody2D.velocity = new Vector2(transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);	

		// If the enemy has one hit point left and has a damagedEnemy sprite...
		if(HP == 1 && damagedEnemy != null)
			// ... set the sprite renderer's sprite to be the damagedEnemy sprite.
			ren.sprite = damagedEnemy;
			
		// If the enemy has zero or fewer hit points and isn't dead yet...
		if(HP <= 0 && !dead)
			// ... call the death function.
			Death ();
	}
	
	public void Hurt()
	{
		// Reduce the number of hit points by one.
		state = ENEMYSTATE.ENEMYHURT;
	//	animator.SetTrigger("Hurt");
		HP--;
	}
	
	void Death()
	{

		state = ENEMYSTATE.ENEMYDEATH;
		// Find all of the sprite renderers on this object and it's children.
		SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();
	//	moveSpeed = 0.0f;
		this.collider2D.enabled = false;
		animator.SetTrigger("Death");
		//yield return new WaitForSeconds(0.1f);

		//collider.enabled = false;

		// Disable all of them sprite renderers.
		foreach(SpriteRenderer s in otherRenderers)
		{
			s.enabled = false;
		}
	//	Destroy (this.gameObject.collider

		//Destroy (this.gameObject.rigidbody2D);

		// Re-enable the main sprite renderer and set it's sprite to the deadEnemy sprite.
		ren.enabled = true;
		ren.sprite = deadEnemy;

		// Increase the score by 100 points
		score.score += 100;
		   
		// Set dead to true.
		dead = true;

		// Allow the enemy to rotate and spin it by adding a torque.
		rigidbody2D.fixedAngle = false;
		rigidbody2D.AddTorque(Random.Range(deathSpinMin,deathSpinMax));

		// Find all of the colliders on the gameobject and set them all to be triggers.
		Collider2D[] cols = GetComponents<Collider2D>();
		foreach(Collider2D c in cols)
		{
			c.isTrigger = true;
		}

		// Play a random audioclip from the deathClips array.
		int i = Random.Range(0, deathClips.Length);
		AudioSource.PlayClipAtPoint(deathClips[i], transform.position);

		// Create a vector that is just above the enemy.
		Vector3 scorePos;
		scorePos = transform.position;
		scorePos.y += 1.5f;

		// Instantiate the 100 points prefab at this point.
		Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
	}


	public void Flip()
	{
		facingright = !facingright;
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
	void getClosestEnemy()
	{

		flag = true;
		GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag(targetTag);
		float closestDistSqr = Mathf.Infinity;
		closestEnemy = null;
		
		foreach(GameObject taggedEnemy in taggedEnemys)
		{
			objectPos = taggedEnemy.transform.position;
			dist = (objectPos.x - transform.position.x);
			
			if (dist <fAttackDist  && dist >0)
			{

					closestDistSqr = dist;
					closestEnemy = taggedEnemy.transform;
			
			}
			else{
				state = ENEMYSTATE.ENEMYRUN;
				animator.SetTrigger ("Run");
				moveSpeed = realmoveSpeed; 
			}
		}
		target = closestEnemy;
		
	}	

}
