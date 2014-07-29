using UnityEngine;
using System.Collections;

public class ItemManage : MonoBehaviour {

	GameObject guiControl;
	GameGUI gameGUI;
	GUIText itemInfo;
	public GameObject oppositeObject;
	// Use this for initialization
	void Start () {
		guiControl = GameObject.Find("TileMap");
		gameGUI = guiControl.GetComponent <GameGUI> ();
//		itemInfo = gameObject.AddComponent <GUIText> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
	//		print("player Entered!!!");	
			gameGUI.itemList.Add(this.gameObject.name);
			if(oppositeObject != null){
				Destroy(oppositeObject);
			}
			Destroy(this.gameObject);
		}
	}
}
