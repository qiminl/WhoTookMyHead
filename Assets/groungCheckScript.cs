using UnityEngine;
using System.Collections;

public class groungCheckScript : MonoBehaviour {

	public GameObject player;
	PlayerControl playerControl;
	// Use this for initialization
	void Start () {
		playerControl = player.GetComponent<PlayerControl> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "ground") {
			print("Encountered platforms");
				playerControl.grounded = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "ground") {
			print("Exit platforms");
			playerControl.grounded = false;
		}
	}
}
