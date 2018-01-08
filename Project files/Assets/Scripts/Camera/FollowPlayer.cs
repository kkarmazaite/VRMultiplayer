using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	private GameObject player;       //Public variable to store a reference to the player game object
	// LateUpdate is called after Update each frame
	private GameManager gameManager;
	void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		if (gameManager.VRMode) {
			GetComponent<GvrViewer> ().VRModeEnabled = true;
		} else {
			GetComponent<GvrViewer> ().VRModeEnabled = false;
		}

	}
	void Update () 
	{
		if (gameManager.VRMode) {
			GetComponent<GvrViewer> ().VRModeEnabled = true;
		} else {
			GetComponent<GvrViewer> ().VRModeEnabled = false;
		}
		player = GameObject.Find ("PlayerHead");
		if(player!=null){
			// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
			transform.position = player.transform.position;}
	}
	public void PlaySound(){
		if (GameObject.Find ("GameManager").GetComponent<GameManager> ().Music) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
		}
	}
}