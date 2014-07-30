using UnityEngine;
using System.Collections;

public class ItemManage : MonoBehaviour {

	GameObject guiControl;
	GameGUI gameGUI;
	GUIText itemInfo;
	public GameObject oppositeObject;
	public string effect;

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
			showEffect(effect);
			if(oppositeObject != null){
				Destroy(oppositeObject);
			}
			Destroy(this.gameObject);
		}
	}

	void showEffect(string effect){
		if (effect == "GET_RECTHEAD") {
			GameObject player = GameObject.Find ("player");
			PlayerControl playerControl = player.GetComponent<PlayerControl> ();
			playerControl.headNum = 1;
			GameObject NPC = GameObject.Find ("NPC1(clone)");
			NPCMovement npcControl = NPC.GetComponent<NPCMovement>();
			npcControl.wordsToSay = "You can use the Head to Fight those Enemies now\n" +
				"Try to press the Z buttom to attack!~";

		}
		else if (effect == "GET_TRIANGLEHEAD") {
			
			GameObject player = GameObject.Find ("player");
			PlayerControl playerControl = player.GetComponent<PlayerControl> ();
			playerControl.headNum = 2;	
			GameObject NPC = GameObject.Find ("NPC1(clone)");
			NPCMovement npcControl = NPC.GetComponent<NPCMovement>();
			npcControl.wordsToSay = "You can use the Head to Fight those Enemies now\n" +
				"Try to press the Z buttom to attack!~";				
		}
	}
}
