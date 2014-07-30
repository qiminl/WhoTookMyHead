using UnityEngine;
using System.Collections;
using System;

public class NPCMovement : MonoBehaviour {


	public bool textDisplay;
	public string wordsToSay;
	public string inputWords;
	// Use this for initialization
	void Start () {
		wordsToSay = "";
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown(0))
		{

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit();

			print("ray = " + ray);
			if (Physics.Raycast (ray, out hit))
			{  
				if(hit.transform.gameObject == gameObject){
					// deal with the inputWords
			//		int j = 0;
					print ("inputWords: " + inputWords);
					string[] stringSeperators = new string[] {"endl"};
					string[] lines = inputWords.Split(stringSeperators, StringSplitOptions.None);
					foreach(string s in lines){
						if(s.Trim() != ""){
							wordsToSay += (s + "\n");
						}
					}
				}
				else{
					wordsToSay = "";
				}

			}
			else{
				wordsToSay = "";
			}
		}
		//print (gameObject.name + "\t says: " + wordsToSay);
	
	}
	void showWords(string s){
		wordsToSay = s;
	}
	void OnGUI(){
	//	GUIStyle wordsStyle = new GUIStyle();
	//	wordsStyle.fontSize  = 14;
		if (wordsToSay != "") {
			GUISkin guiSkin = Resources.Load("DialogSkin") as GUISkin;
		//	print ("name of GUI skin" + guiSkin.name);
			GUI.color = new Color(255, 255, 255, 0.9f);

			GUIStyle style = new GUIStyle(guiSkin.box);

			style.fontSize = 24;
		//	style.
			GUIContent boxText = new GUIContent("" + wordsToSay);
			style.alignment = TextAnchor.MiddleLeft;
			Rect boxGUI = new Rect( 50, Screen.height - 150, Screen.width - 100, 150);
			GUI.Box(boxGUI, boxText, style);
		//	Vector3 viewPointPos = Camera.main.ScreenToViewportPoint(new Vector3(0, 350));
		//	GUI.Label (new Rect (0, 350, 700, 50), wordsToSay);
				}
	}
}
