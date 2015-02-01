using UnityEngine;
using System.Collections;

public class chooseStyle : MonoBehaviour {
	public GameObject maxi;
	public GameObject flare;
	public GameObject panels;
	public bool showbutton=true;
	public changeMaxi maxiColors;
	public changePanels panelColors;
	public changeCloth flareColors;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public int i = 0;


	void OnGUI () {
		maxi = GameObject.Find ("Maxi");
		flare = GameObject.Find ("Fit/Flare");
		panels = GameObject.Find ("Sophia");

		if (showbutton!=false) {
			Debug.Log (showbutton);

						// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
				if (GUI.Button (new Rect (180, 440, 100, 40), "Flare")) {

				Debug.Log (showbutton);
				Destroy (maxi);
					Destroy (flare);
					Destroy (panels);
					i=1;
			
				GUI.enabled=false;
					

				}
				
						// Make the second button.
				else if (GUI.Button (new Rect (350, 440, 100, 40), "Maxi")) {

				Destroy (maxi);
						Destroy (flare);
						Destroy (panels);
				i=2;
				Debug.Log (showbutton);
				GUI.enabled=false;

				}
	
				else if (GUI.Button (new Rect (550, 440, 100, 40), "Panels")) {

						Destroy (maxi);
						Destroy (flare);
						Destroy (panels);
						i=3;
				Debug.Log (showbutton);
				GUI.enabled=false;

						
						

				}
				}

		if (i == 1) {

						GameObject flar = new GameObject ();
						flar.gameObject.AddComponent ("changeCloth");
				} else if (i == 2) {

						GameObject max = new GameObject ();
						max.gameObject.AddComponent ("changeMaxi");
				} else if (i==3) {

						GameObject pan = new GameObject ();
						pan.gameObject.AddComponent ("changePanels");
				}
			
			
		}
}