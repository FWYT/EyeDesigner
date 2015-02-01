using UnityEngine;
using System.Collections;

public class LoadingScreen46 : MonoBehaviour
{
	//We make a static variable to our LoadingScreen instance
	static LoadingScreen46 instance;
	//reference to gameobject with the static image 
	GameObject loadingScreenImage;

	IEnumerator wait(){
				yield return new WaitForSeconds (20);
		}
	//function which executes on scene awake before the start function
	void Awake()
	{
		//find the ImageLS gameobject from the Hierarchy
		loadingScreenImage = GameObject.Find("ImageLS");
	
		instance = this;    
		instance.loadingScreenImage.SetActive(true);

	}
	
	void Update()
	{
		//StartCoroutine (wait ());
		//Destroy (loadingScreenImage);
		//Application.LoadLevel("redcubescene");

	}


	
}