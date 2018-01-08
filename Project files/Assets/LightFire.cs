using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightFire : MonoBehaviour {
	public float fillTime = 2f;
	public GameObject Fire;
	private float timer;
	private Slider mySlider;
	private bool gazeAt;
	public bool FirewoodCollected;
	float distance;
	private Coroutine fillBarRoutine;
	public GameObject camera;
	private GameManager gameManager;
	private PickUpManager pickupManager;

	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		pickupManager = GameObject.Find ("Manager").GetComponent<PickUpManager> ();
		FirewoodCollected = false;
		mySlider = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Slider> ();
		if (mySlider == null) {
		}
	}
	void Update(){
		distance = Vector3.Distance (transform.position, camera.transform.position);
		if (pickupManager.fireLit) {
			LitFireplace ();
		}
		if (gameManager.Music) {
			Fire.GetComponent<AudioSource> ().enabled = true;
		} else {
			Fire.GetComponent<AudioSource> ().enabled = false;
		}
	}
	public void PointerEnter(){
		if (distance < 1.5f&&FirewoodCollected) {
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
		pickupManager.LitFireRPC ();
		this.gameObject.transform.GetChild (0).GetChild (0).gameObject.SetActive (false);
	}
	public void LitFireplace(){
		Fire.SetActive (true);
	}
}
	