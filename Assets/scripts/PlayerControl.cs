using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.

	public bool died = false;
	public float moveForce = 1000f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
//	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 50000f;			// Amount of force added when the player jumps.

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	public bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
	public int maxHP;
	public int remainingHP;
	public int fillHPmaxWidth = 100;
//	public Transform camPos;
	GUITexture fillHP;
	public int headNum;	// 0 for headLess, 1 for rectHead, 2 for triangleHead

	void Start(){
//		camPos = transform.Find("/Main Camera/CamPos");
//		camPos.position = transform.position;

	}

	void Awake ()
	{
		// Setting up references.
		groundCheck = transform.Find ("groundCheck");
		anim = GetComponent<Animator> ();
		GameObject HP = GameObject.Find("fillHP");
//		fillHP = HP.GetComponent (typeof(GUITexture)) as GUITexture;
		maxHP = 100;
		remainingHP = maxHP;

	}

	void Update ()
	{
		if (died == true) {
			print ("player is dead");
			anim.SetBool("Dead", true);
<<<<<<< HEAD
				Destroy(this.gameObject, 0.5f);		
			}
					// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
	//		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground")); 

			print ("player grounded ?" + grounded);
			anim.SetBool ("Grounded", grounded);
			// If the jump button is pressed and the player is grounded then the player should jump.
			if (Input.GetButtonDown ("Jump") && grounded)
					jump = true;
			if (remainingHP <= 0) {
				died = true;		
			}
=======
			Destroy(this.gameObject, 0.5f);		
		}
				// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground")); 
		
		print ("player grounded ?" + grounded);
		anim.SetBool ("Grounded", grounded);
		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetButtonDown ("Jump") && grounded)
				jump = true;
		if (remainingHP <= 0) {
			died = true;		
		}
>>>>>>> FETCH_HEAD
		if (grounded) {
	//		camPos.position = groundCheck.position;		
		}
	//	print ("camPos = " + camPos.positio//n);
	}

	void FixedUpdate ()
	{

		if (headNum == 0) {
			anim.SetBool ("headLess", true);
			anim.SetBool ("rectHead", false);
			anim.SetBool ("triangleHead", false);
		}
		else if (headNum == 1) {
			anim.SetBool ("headLess", false);
			anim.SetBool ("rectHead", true);
			anim.SetBool ("triangleHead", false);
					
		}
		else if (headNum == 2) {
			anim.SetBool ("headLess", false);
			anim.SetBool ("rectHead", false);
			anim.SetBool ("triangleHead", true);
			
		}
//			Rect pixelInset = fillHP.pixelInset;
//			pixelInset.width = 100 * remainingHP / maxHP;
	//		fillHP.pixelInset = pixelInset;

			// Cache the horizontal input.
			float h = Input.GetAxis ("Horizontal");

			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetFloat ("Speed", Mathf.Abs (h));
			anim.SetFloat ("VerticalSpeed", rigidbody2D.velocity.y);

			// ignore collide with platform when jumping
			Physics2D.IgnoreLayerCollision (8, 9, rigidbody2D.velocity.y > 0);

			// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
			if (h * rigidbody2D.velocity.x < maxSpeed)
		// ... add a force to the player.
					rigidbody2D.AddForce (Vector2.right * h * moveForce);

			// If the player's horizontal velocity is greater than the maxSpeed...
			if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
		// ... set the player's velocity to the maxSpeed in the x axis.
					rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

			// If the input is moving the player right and the player is facing left...
			if (h > 0 && !facingRight)
		// ... flip the player.
					Flip ();
	// Otherwise if the input is moving the player left and the player is facing right...
	else if (h < 0 && facingRight)
		// ... flip the player.
					Flip ();

			// If the player should jump...
			if (jump) {
					// Set the Jump animator trigger parameter.
					anim.SetTrigger ("Jump");

					// Add a vertical force to the player.
					rigidbody2D.AddForce (new Vector2 (0f, jumpForce));

					// Make sure the player can't jump again until the jump conditions from Update are satisfied.
					jump = false;
			}
			edgeDetection ();
	}

	void Flip ()
	{
			// Switch the way the player is labelled as facing.
			facingRight = !facingRight;

			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
	}

	void edgeDetection ()
	{
		/*	if (transform.position.x < -10) {
					transform.position = new Vector3 (-10f, transform.position.y, transform.position.z);
		
			} else if (transform.position.x > 35) {
					transform.position = new Vector3 (35f, transform.position.y, transform.position.z);		
			}*/

			if (transform.position.y < -20) {
					died = true;
		
			}

	}
void OnCollisionEnter2D(Collision2D other){

	if (other.gameObject.tag == "monsters") {
		print("monster encountered!");	
			// droping
			if(rigidbody2D.velocity.y < 0 && !grounded){
				monsterMovement monster = other.gameObject.GetComponent <monsterMovement>();
				monster.isDead = true;
				Destroy(other.gameObject, 0.1f);

			}
	}
}
/*
void OnTriggerEnter2D(Collider2D other) {
	print ("sth entered!!!");

	// if it is ground
	if (other.gameObject.layer == 8) {
		print("groundddddd");
		// if player is going up, ignore
		if(rigidbody2D.velocity.y < 0){
			print("lalalalalal");
			rigidbody2D.velocity = Vector3.zero;
			rigidbody2D.gravityScale = 0;
			rigidbody2D.isKinematic = true;
			rigidbody2D.angularVelocity = 0;
		}
	}
}
*/
	/*
public IEnumerator Taunt()
{
	// Check the random chance of taunting.
	float tauntChance = Random.Range(0f, 100f);
	if(tauntChance > tauntProbability)
	{
		// Wait for tauntDelay number of seconds.
		yield return new WaitForSeconds(tauntDelay);

		// If there is no clip currently playing.
		if(!audio.isPlaying)
		{
			// Choose a random, but different taunt.
			tauntIndex = TauntRandom();

			// Play the new taunt.
			audio.clip = taunts[tauntIndex];
			audio.Play();
		}
	}
}


int TauntRandom()
{
	// Choose a random index of the taunts array.
	int i = Random.Range(0, taunts.Length);

	// If it's the same as the previous taunt...
	if(i == tauntIndex)
		// ... try another random taunt.
		return TauntRandom();
	else
		// Otherwise return this index.
		return i;
}
*/
}
