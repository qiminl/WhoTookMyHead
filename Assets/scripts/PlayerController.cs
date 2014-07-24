using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Animator anim;

	public float moveSpeed = 8;
	public float jumpSpeed = 5;
	bool jump = false;
	bool grounded = false;
	public GameObject groundCheck;
	float groundRadius = 0.2f;
	public LayerMask groundMask;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		groundCheck = GameObject.Find("groundCheck");
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"));  

		anim.SetBool ("Grounded", grounded);
		float move = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = Vector2.right * move * moveSpeed;	
		anim.SetFloat ("moveSpeed", Mathf.Abs(rigidbody2D.velocity.x));
		print ("vertical speed = " + rigidbody2D.velocity.y);

		if (move > 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0);		
		}
		else if(move < 0) {
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			jump = true;		
		}

		if (jump) {
			rigidbody2D.AddForce(new Vector2(0, 30000));
			jump = false;
		}

	}
	
}
