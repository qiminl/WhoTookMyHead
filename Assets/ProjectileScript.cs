using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

	float timeExits;
	float currentTime;
	// Use this for initialization
	void Start () {
		currentTime = 0;
		timeExits = currentTime;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		// if it exists more than 1.5 seconds
		if (currentTime - timeExits >= 0.5f) {
			Destroy(gameObject, 0.1f);	
		}
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {

			Destroy(other.gameObject, 0.1f);
			Destroy(gameObject, 0.1f);
		}
	}
}
