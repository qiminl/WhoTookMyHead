using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

	public string name;
	public string questInfo;
	public bool isComplete;
	public ArrayList itemList = new ArrayList();
	Quest(){
		name = "default";
		questInfo = "undefined";
	}
	Quest(string name){
		this.name = name;
		questInfo = "undefined";
	}
	Quest(string name, string questInfo){
		this.name = name;
		this.questInfo = questInfo;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
