using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeMenu : MonoBehaviour {
	public int callMenu;
	public float fillTime = 0.3f;
	private float timer;
	private bool gazeAt;
	private Coroutine fillBarRoutine;
	public void PointerEnter(){
		if (gameObject.name == "PlayerMenuGaze") {
			GameObject.Find ("PlayerMenuCanvas").GetComponent<PlayerMenuManager> ().Menu (callMenu);
		} else {
			gazeAt = true;
			fillBarRoutine = StartCoroutine (FillBar ());
		}
		}
	public void PointerExit(){
			gazeAt = false;
			if (fillBarRoutine != null) {
				StopCoroutine (fillBarRoutine);
			}
			timer = 0f;
	}
	private IEnumerator FillBar(){
		timer = 0f;
		while (timer < fillTime) {
			timer += Time.deltaTime;
			yield return null;

			if (gazeAt)
				continue;

			timer = 0f;
			yield break;
		}
		OnBarFilled ();
	}
	public void OnBarFilled(){
		GameObject.Find ("PlayerMenuCanvas").GetComponent<PlayerMenuManager>().Menu (callMenu);
	}
}
