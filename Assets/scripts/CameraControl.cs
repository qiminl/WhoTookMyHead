using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("left")) {
			transform.position = new Vector3(transform.position.x - 3, transform.position.y, transform.position.z);		
		}
		else if (Input.GetKey ("right")) {
			transform.position = new Vector3(transform.position.x + 3, transform.position.y, transform.position.z);		
		}
		else if (Input.GetKey ("up")) {
			transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);		
		}
		else if (Input.GetKey ("down")) {
			transform.position = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);		
		}
	}
}
