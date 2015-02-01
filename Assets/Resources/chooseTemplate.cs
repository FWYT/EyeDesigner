using UnityEngine;
using System.Collections;


using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

// Change the material when certain poses are made with the Myo armband.
// Vibrate the Myo armband when a fist pose is made.
public class chooseTemplate : MonoBehaviour
{
	// Myo game object to connect with.
	// This object must have a ThalmicMyo script attached.
	public GameObject myo = null;

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;

	public changeMaxi maxiColors;
	public changePanels panelColors;
	public changeCloth clothColors;
	
	
	

	void Start()
	{

	}
	
	// The pose from the last update. This is used to determine if the pose has changed
	// so that actions are only performed upon making them rather than every frame during
	// which they are active.
	private Pose _lastPose = Pose.Unknown;
	
	// Update is called once per frame.
	void Update ()
	{
		// Access the ThalmicMyo component attached to the Myo game object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		
		// Check if the pose has changed since last update.
		// The ThalmicMyo component of a Myo game object has a pose property that is set to the
		// currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
		// detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
		// is not on a user's arm, pose will be set to Pose.Unknown.
		
		
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;
			
			// Vibrate the Myo armband when a fist is made.
			if (thalmicMyo.pose == Pose.FingersSpread) {
				GameObject maxi = GameObject.Find ("MaxiColors");
				changeMaxi maxiScript = (changeMaxi) maxi.GetComponent(typeof(changeMaxi));
				maxiScript.Start();
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
				
				// Change material when wave in, wave out or double tap poses are made.
			} else if (thalmicMyo.pose == Pose.WaveIn) {
				GameObject flare = GameObject.Find ("FlareColors");
				changeCloth flareScript = (changeCloth) flare.GetComponent(typeof(changeCloth));
				flareScript.Start();
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
				
			} else if (thalmicMyo.pose == Pose.WaveOut) {
				Debug.Log ("wave out");
				GameObject panels = new GameObject();
				SpriteRenderer renderer = panels.gameObject.AddComponent<SpriteRenderer>();
				renderer.sprite = sprite3;
				panelColors = panels.gameObject.AddComponent<changePanels>();
				//panelColors.myo = myo;
				panels.transform.localScale -= new Vector3 (2F, 2F, 2F); // panel
				panels.transform.position += new Vector3 (-1.6F, 4.1F, 0.5F); //panel
				panels.transform.Rotate(0F,90F,0F);//panel
				panelColors.Start();
				//panelColors.Update();




				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			} 
			
			ExtendUnlockAndNotifyUserAction (thalmicMyo);
		}
	}
	
	
	// Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
	// recognized.
	void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
	{
		ThalmicHub hub = ThalmicHub.instance;
		
		if (hub.lockingPolicy == LockingPolicy.None) {
			myo.Unlock (UnlockType.Timed);
		}
		
		myo.NotifyUserAction ();
	}
}

