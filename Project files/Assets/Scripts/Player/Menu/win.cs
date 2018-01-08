using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour {
	public GameObject winMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void WinMenu () {
		winMenu.SetActive (true);
		GameObject.Find ("Me").GetComponent<Movement> ().Position (true);

	}
}
