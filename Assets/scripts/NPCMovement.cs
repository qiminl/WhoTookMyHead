using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour {


	public bool textDisplay;
	public string wordsToSay;
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
				print("mouseClicked!");
				if(gameObject.name == "NPC1"){
					showWords("Hello Youngster, I guess your head is taken by the Head Evil." +
						"You need to learn your control to find your head\n" +
						"Try to use Left Arrow Key and Right Arrow to move around, " +
					          "And space button to jump\n");
				}

			}
			else{
				wordsToSay = "";
			}
		}
	
	}
	void showWords(string s){
		wordsToSay = s;
	}
	void OnGUI(){
	//	GUIStyle wordsStyle = new GUIStyle();
	//	wordsStyle.fontSize  = 14;
		if (wordsToSay != "") {
			GUISkin guiSkin = Resources.Load("DialogSkin") as GUISkin;
			print ("name of GUI skin" + guiSkin.name);
			GUI.color = new Color(255, 255, 255, 0.9f);

			GUIStyle style = new GUIStyle(guiSkin.box);

			style.fontSize = 24;
		//	style.
			GUIContent boxText = new GUIContent("" + wordsToSay);
			style.alignment = TextAnchor.MiddleLeft;
			Rect boxGUI = new Rect( 50, Screen.height - 100, Screen.width - 100, 100);
			GUI.Box(boxGUI, boxText, style);
		//	Vector3 viewPointPos = Camera.main.ScreenToViewportPoint(new Vector3(0, 350));
		//	GUI.Label (new Rect (0, 350, 700, 50), wordsToSay);
				}
	}
}
