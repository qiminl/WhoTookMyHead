using UnityEngine;
using System.Collections;

public class ExitDoorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			print("exit");
			if(Input.GetKey("up")){
				Application.LoadLevel("Main Scene");
			}		
		}
	}
}
