using UnityEngine;
using System.Collections;

public class QuestList : MonoBehaviour {

	public ArrayList questList;
	// Use this for initialization
	void Start () {
		questList = new ArrayList();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void findQuest(string name){
		for (int i = 0; i < questList.Count; i++) {
			Quest quest = questList[i] as Quest;
			if(name == quest.name){
				print ("found the quest!");
				questList.Remove(quest);
			}		
		}
	}

	// show the To DO list
	void OnGUi(){
		for (int i = 0; i < questList.Count; i++) {
			GUI.Box ()		
		}
	}
}
