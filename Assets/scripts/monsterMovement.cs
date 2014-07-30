using UnityEngine;
using System.Collections;

public class monsterMovement : MonoBehaviour {

	public bool facingRight = true;			// For determining which way the player is currently facing.


	public float xSpeed = 1;
	public bool turned = false;
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
	private Vector2 groundedPos;
	public bool isAttack = false;
	public bool isDead = false;
	private bool isAttackedFlag = false;
	private float currentTime = 0;
	private float attackInterval = 0;
	private int damage = 30;
	private bool droped = false;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
		groundCheck = transform.Find ("/monster/groundCheck");
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("isAttack", isAttack);
		anim.SetBool ("isDead", isDead);
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground")); 
		print("grounded?  " + grounded);
		// record on ground position
		if (grounded) {
			groundedPos = transform.position;
		}

		if (!grounded && !turned) {
			Flip (); 
		}
		else if (grounded && turned) {
			turned = false;
		}
		// if not grounded and falling, return to the position before drops
		if (!grounded && rigidbody2D.velocity.y < 0) {
			transform.position = groundedPos;	
		}
		rigidbody2D.velocity = new Vector2 (xSpeed, rigidbody2D.velocity.y);

		if (isAttack == true) {
			currentTime += Time.deltaTime;		
		}

		if (isAttack == true && (currentTime - attackInterval) > 1) {
			print("wallalaallal");
			dealDamageToPlayer(player);
			attackInterval = currentTime;
		}
	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		xSpeed *= -1;
		turned = true;
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "player") {
			currentTime = 0;
			// monster attacks every 0.5 seconds
			isAttack = true;	

		}
		
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.name == "player") {
			isAttack = false;	
			currentTime= 0;
		}
	}

	void dealDamageToPlayer(GameObject player){
		PlayerControl playerControl;
		playerControl = player.GetComponent <PlayerControl> ();
		playerControl.remainingHP -= damage;
		if (playerControl.remainingHP < 0) {
			playerControl.remainingHP = 0;		
		}
	}
}
