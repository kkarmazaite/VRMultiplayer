using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVRModeSprite : MonoBehaviour {
	public GameObject Background, Fill;
	public Sprite OnSprite, OnSpriteGazed, OffSprite, OffSpriteGazed;
	private bool VRMode;
	private GameManager gameManager;
	public void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		VRMode = !gameManager.VRMode;
		ChangeVRMode ();
	}
	public void VRModeOn(){
		Background.GetComponent<Image> ().sprite = OnSprite;
		Fill.GetComponent<Image> ().sprite = OnSpriteGazed;
	}
	public void VRModeOff(){
		Background.GetComponent<Image> ().sprite = OffSprite;
		Fill.GetComponent<Image> ().sprite = OffSpriteGazed;
	}
	public void ChangeVRMode(){
		if (VRMode) {
			VRMode = false;
			VRModeOff();
			gameManager.VRMode = false;
		} else {
			VRMode = true;
			VRModeOn();
			gameManager.VRMode = true;
		}
	}
}
