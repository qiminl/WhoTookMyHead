using UnityEngine;
using System.Collections;
//using UnityEditor;

public class GameGUI : MonoBehaviour {
	public ArrayList itemList;
	private int ArrayLength;
	public ArrayList itemObjectList;
	private GameObject player;
	public GameObject entryDoor;
	void Start () {
		Vector3 playerInsPos = entryDoor.transform.position;
		Object playerObject = Resources.Load ("player", typeof(GameObject));
		player = Instantiate (playerObject, playerInsPos, Quaternion.identity) as GameObject;
		player.name = "player";
		if (player == null) {
			print ("player not created");		
		}
		itemList = new ArrayList ();
		ArrayLength = itemList.Count;
		itemObjectList = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			Vector3 playerInsPos = entryDoor.transform.position;
			Object playerObject = Resources.Load ("player", typeof(GameObject));
			player = Instantiate (playerObject, playerInsPos, Quaternion.identity) as GameObject;
			player.name = "player";
		}
		Vector2 StartScrrenPos = new Vector2 (-0.3f, -0.3f);

		if (ArrayLength < itemList.Count) {
			for (int i = ArrayLength; i < itemList.Count; i++) {
				Object prefab = Resources.Load ("itemBox", typeof(GameObject));
				GameObject clone = Instantiate (prefab, Vector2.zero, Quaternion.identity) as GameObject;
				
				SpriteRenderer cloneSprite = clone.GetComponent<SpriteRenderer> ();
				string itemSpriteName = itemList [i] as string;
				//print ("itemSprite = " + itemSpriteName);
				ItemListControl itemControl = clone.GetComponent<ItemListControl>();
				itemControl.spriteName = itemSpriteName;
				clone.name = itemSpriteName;
				// put clone item into the itemObjectList
				itemObjectList.Add(clone);
				
			}
			ArrayLength = itemList.Count;
		}

		
		// move all item list position
		for(int i = 0; i < itemObjectList.Count; i++){
			Vector2 itemScreenPos = new Vector2 (StartScrrenPos.x + i * 0.1f, StartScrrenPos.y);
			Vector3 itemViewPos = new Vector3(itemScreenPos.x, itemScreenPos.y, 2);

			Vector2 itemPos = Camera.main.ViewportToWorldPoint(itemViewPos);
			//print("itemScreenPos ["+i+"] =" + itemScreenPos);
			//print("itemPos [" + i + "]" + itemPos);
			GameObject itemObject = itemObjectList[i] as GameObject;
			itemObject.transform.localPosition = itemPos;
			
		}

	}


	/*	
		Texture2D emptyTex = Resources.Load ("emptyHP") as Texture2D;
		Texture2D fullTex = Resources.Load ("fillHP") as Texture2D;
		Vector2 pos = new Vector2 (10, 10);
		Vector2 size = new Vector2 (128, 64);
		float barDisplay = 1;
		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
			GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
			
			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
				GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
			GUI.EndGroup();
		GUI.EndGroup();
*/
}
