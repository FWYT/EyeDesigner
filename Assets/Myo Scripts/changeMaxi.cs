using UnityEngine;
using System.Collections;


// Change the material when certain poses are made with the Myo armband.
// Vibrate the Myo armband when a fist pose is made.
public class changeMaxi : MonoBehaviour
{

	public Sprite[] clothSprite;
	public int i = 0;
	public GameObject cloth;
	public bool showButton = true;
	public Sprite MaxiS;
	public Sprite FlareS;
	public Sprite PanelS;
	

	

	
	public void Start()
	{
		clothSprite = Resources.LoadAll<Sprite> ("Maxis");
		cloth = new GameObject ();
		cloth.AddComponent<SpriteRenderer> ();
		
		cloth.GetComponent<SpriteRenderer> ().sprite = clothSprite [0];
		cloth.transform.localScale = new Vector3 (0.42F, 0.42F, 0.42F); // maxis
		cloth.transform.position += new Vector3 (-1.6F, 3.9F, 0.5F); //maxis
		cloth.transform.Rotate(180F,90F,180F);//maxis
	}
	


	
	void OnGUI () {
				if (showButton) {
						if (GUI.Button (new Rect (650, 240, 100, 40), "Right")) {
								if (i >= clothSprite.Length - 1) {
										i = 0;
								} else {
										i += 1;
								}
			
								cloth.GetComponent<SpriteRenderer> ().sprite = clothSprite [i];
			
			
			
						} else if (GUI.Button (new Rect (80, 240, 100, 40), "Left")) {
								if (i > 0) {
										i -= 1;
								} else {
										i = clothSprite.Length - 1;
								}
				cloth.GetComponent<SpriteRenderer> ().sprite = clothSprite [i];}

				else if (GUI.Button (new Rect (370, 350, 100, 40), "Back")) {

				Application.LoadLevel("redcubescene");
				}
				
				
			}
		}
		
			

}


