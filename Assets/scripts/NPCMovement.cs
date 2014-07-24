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
				showWords("hello llaalskjaljlajdlajlsajdlasjlajdljsdl");

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
						GUI.Box (new Rect (0, 350, 700, 50), wordsToSay);
				}
	}
}
