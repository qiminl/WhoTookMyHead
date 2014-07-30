using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	
	public string name;
	public Sprite itemSprite;
	public Texture2D itemTexture;
	public Item(){
		name = "";
		itemSprite = null;
		itemTexture = null;
	}
}
