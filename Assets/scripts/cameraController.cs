using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {


	GameObject player;
	public float xSpeed = 0.1f;
	public float ySpeed = 0.1f;
	// Use this for initialization
	void Start () {

		player = GameObject.Find("player");
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -4);
		edgeDetection ();


	}
	void edgeDetection(){
		if (transform.position.x < -6.3) {
			transform.position = new Vector3 (-6.3f, transform.position.y, -4);
			
		} 
		else if (transform.position.x > 31) {
			transform.position = new Vector3(31f, transform.position.y, -4);		
		}
		if (transform.position.y < -2.4) {
			transform.position = new Vector3 (transform.position.x,-2.4f , -4);
			
		}
		else if (transform.position.y > 4) {
			transform.position = new Vector3 (transform.position.x,4f , -4);
			
		}
	}
}
