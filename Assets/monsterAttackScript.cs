using UnityEngine;
using System.Collections;

public class monsterAttackScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			print ("attack player !");
			GameObject parent = transform.parent.gameObject;
			monsterMovement parentControl = parent.GetComponent<monsterMovement>();
			parentControl.isAttack = true;
			parentControl.dealDamageToPlayer(other.gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			print ("attack player !");
			GameObject parent = transform.parent.gameObject;
			monsterMovement parentControl = parent.GetComponent<monsterMovement>();
			parentControl.isAttack = false;
			//parentControl.dealDamageToPlayer(other.gameObject);
		}
	}
}
