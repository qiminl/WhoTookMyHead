using UnityEngine;
using System.Collections;

public class MeleeAttackScript : MonoBehaviour {

	GameObject player;
	PlayerControl playerControl;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
		playerControl = player.GetComponent<PlayerControl> ();
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy" && playerControl.isAttack && playerControl.headNum == 2) {
			// encountered Enemy!
			print("fight Enemy!");
			Destroy(other.gameObject);
		}
	}
}
