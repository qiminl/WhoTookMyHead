using UnityEngine;
using System.Collections;

public class ItemListControl : MonoBehaviour {

	
	public Sprite[] sprites;
	private SpriteRenderer spriteRenderer;
	public string spriteName;
	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < sprites.Length; i++) {
			string currentSpriteName = sprites[i].ToString();
			print("currentSpriteName = " + currentSpriteName);
			string realSpriteName = spriteName + " (UnityEngine.Sprite)";
			print ("realSpriteName = " + realSpriteName);
			if(currentSpriteName == realSpriteName){
				print("currentSpriteName ======== spriteName");
				spriteRenderer.sprite = sprites[i];
				print("sprite should changed");
			}		
		}
	
	}
}
