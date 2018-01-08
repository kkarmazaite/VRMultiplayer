using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeMusicBtnSprite : MonoBehaviour {
	public GameObject Background, Fill;
	public Sprite OnSprite, OnSpriteGazed, OffSprite, OffSpriteGazed;
	private bool PlayMusic=true;
	private GameManager gameManager;
	public void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		PlayMusic = !gameManager.Music;
		ChangeMusicMode ();
	}
	public void MusicOn(){
		Background.GetComponent<Image> ().sprite = OnSprite;
		Fill.GetComponent<Image> ().sprite = OnSpriteGazed;
	}
	public void MusicOff(){
		Background.GetComponent<Image> ().sprite = OffSprite;
		Fill.GetComponent<Image> ().sprite = OffSpriteGazed;
	}
	public void ChangeMusicMode(){
		if (PlayMusic) {
			PlayMusic = false;
			MusicOff();
			gameManager.Music = false;
		} else {
			PlayMusic = true;
			MusicOn();
			gameManager.Music = true;

		}
	}
}
