using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private static GameManager playerInstance;
	public bool lostConnection=false;
	//public bool hasWon=false;
	public bool VRMode=true;
	public bool Music=true;
	public string PlayerName;
	void Awake(){
		DontDestroyOnLoad (this);

		if (playerInstance == null) {
			playerInstance = this;
		} else {
			DestroyObject (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Application.internetReachability == NetworkReachability.NotReachable) {
			lostConnection = true;
		} else {
			lostConnection = false;
		}

		/*if (Music) {
			GameObject.Find ("GvrMain").GetComponent<AudioSource> ().enabled = true;
			GameObject.Find ("Fire").GetComponent<AudioSource> ().enabled = true;
		} else {
			GameObject.Find ("GvrMain").GetComponent<AudioSource> ().enabled = true;
			GameObject.Find ("Fire").GetComponent<AudioSource> ().enabled = false;
			//GameObject.Find ("Main Camera").GetComponent<AudioListener> ().enabled = false;
		}*/
	}
}
