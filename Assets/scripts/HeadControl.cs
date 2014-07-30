using UnityEngine;
using System.Collections;

public class HeadControl : MonoBehaviour {


	public Sprite[] sprites;
	private SpriteRenderer spriteRenderer;
	GameObject player;
	PlayerControl playerControl;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
		playerControl = player.GetComponent <PlayerControl> ();
		spriteRenderer = renderer as SpriteRenderer;

	}
	
	// Update is called once per frame
	void Update () {
		spriteRenderer.sprite = sprites [playerControl.headNum];
		if (playerControl.isAttack && playerControl.headNum == 1) {
				spriteRenderer.sprite = sprites [3];		
		}
		else if (playerControl.isAttack && playerControl.headNum == 2) {
			spriteRenderer.sprite = sprites[0];
		}
	}
}
