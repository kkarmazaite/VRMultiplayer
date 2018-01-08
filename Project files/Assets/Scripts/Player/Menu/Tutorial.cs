using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
	public GameObject text1, text2,text3, text4, NextBtn;
	private int i;
	private GameObject menuIcon;
	// Use this for initialization
	void Start () {
		i = 1;
		GameObject.Find ("Me").GetComponent<Movement> ().Position (true);
		menuIcon = GameObject.Find ("MenuIcon");
		menuIcon.SetActive (false);

	}
	
	public void Help (int n)
	{
		switch (n) {
		case 0:
			i++;
			if (i == 2) {
				text1.SetActive (false);
				text2.SetActive (true);
			}else if (i == 3) {
				text2.SetActive (false);
				text3.SetActive (true);
			}else if (i == 4) {
				text3.SetActive (false);
				text4.SetActive (true);
				NextBtn.SetActive (false);
			}
			break;

		case 1:
			menuIcon.SetActive (true);
			GameObject.Find ("Me").GetComponent<Movement> ().Position (false);
			gameObject.SetActive (false);
			break;
		}
	}
}
