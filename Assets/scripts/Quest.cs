using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

	public string name;
	public string questInfo;
	public bool isComplete;
	public Item[] items;
	public Quest(){
		name = "default";
		questInfo = "undefined";
		isComplete = false;
	}
	public Quest(string name){
		this.name = name;
		questInfo = "undefined";
		isComplete = false;
	}
	public Quest(string name, string questInfo){
		this.name = name;
		this.questInfo = questInfo;
		isComplete = false;
	}

	public bool isCompleted(ArrayList itemList){

		int i = 0;
		while(i < items.Length){
			for(int j = 0; j < itemList.Count; j++){
				Item listedItem = itemList[j] as Item;
				if(items[i] == listedItem){
					i++;
				}
			}
			return false;
		}
		return true;
	}
	public void effect(){
	}
}
