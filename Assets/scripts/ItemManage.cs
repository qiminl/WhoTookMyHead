using UnityEngine;
using System.Collections;

public class ItemManage : MonoBehaviour {

	GameObject guiControl;
	GameGUI gameGUI;
	// Use this for initialization
	void Start () {
		guiControl = GameObject.Find("guiControl");
		gameGUI = guiControl.GetComponent <GameGUI> ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			print("player Entered!!!");	
			gameGUI.itemList.Add(this.gameObject.name);
			if(this.gameObject.name == "mario_kart_wii_item_icons_5"){
				GameObject opposite = GameObject.Find("mario_kart_wii_item_icons_0");
				Destroy(opposite);
			}
			else if(this.gameObject.name == "mario_kart_wii_item_icons_0"){
				GameObject opposite = GameObject.Find("mario_kart_wii_item_icons_5");
				Destroy(opposite);
			}
			Destroy(this.gameObject);
		}
	}
}
