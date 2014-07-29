using UnityEngine;
using System.Collections;

public class groundCheckScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other) {
		print("sth Entered!");
		if (other.gameObject.tag == "ground") {
			print("Encountered!! ground");
			GameObject player = GameObject.Find("player");
			PlayerControl playerControl = player.GetComponent<PlayerControl>();
			playerControl.grounded = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "ground") {
			print("Encountered!! ground");
			GameObject player = GameObject.Find("player");
			PlayerControl playerControl = player.GetComponent<PlayerControl>();
			playerControl.grounded = false;
		}
	}
}
