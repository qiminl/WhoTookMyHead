using UnityEngine;
using System.Collections;

public class PermenetScript : MonoBehaviour {

	public int headNum;
	public ArrayList items;
	public ArrayList quests;
	// Use this for initialization
	void Start () {
		items = new ArrayList ();
		quests = new ArrayList ();
	}
	void Awake(){
		DontDestroyOnLoad (this);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
