using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSlider : MonoBehaviour {
	private float fillTime = 1f;
	public int callMenu;
	private float timer;
	private Slider mySlider;
	private bool gazeAt;
	private Coroutine fillBarRoutine;
	// Use this for initialization
	void Start () {
		mySlider = GetComponent<Slider> ();
		if (mySlider == null) {
		}
	}
	public void PointerEnter(){
		gazeAt = true;
		fillBarRoutine = StartCoroutine (FillBar());
	}
	public void PointerExit(){
		gazeAt = false;
		if (fillBarRoutine != null) {
			StopCoroutine (fillBarRoutine);
		}
		timer = 0f;
		mySlider.value = 0f;
	}
	private IEnumerator FillBar(){
		timer = 0f;
		while (timer < fillTime) {
			timer += Time.deltaTime;
			mySlider.value = timer/ fillTime;
			yield return null;

			if (gazeAt)
				continue;

			timer = 0f;
			mySlider.value = 0f;
			yield break;
		}
		OnBarFilled ();
	}
	public void OnBarFilled(){
		if (gameObject.name == "VRModeBtn") {
			GetComponent<ChangeVRModeSprite> ().ChangeVRMode();
		} 
		else if (gameObject.name == "MusicBtn") {
			GetComponent<ChangeMusicBtnSprite> ().ChangeMusicMode();
		} 
		else if (gameObject.name == "NextBtn"||gameObject.name == "ExitTutorialBtn") {
			GameObject.Find ("Help").GetComponent<Tutorial> ().Help (callMenu);
		} 
		else {
			GameObject.Find ("PlayerMenuCanvas").GetComponent<PlayerMenuManager> ().Menu (callMenu);
		}
	}
}
