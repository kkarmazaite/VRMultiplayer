using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : Photon.MonoBehaviour {
	private float fillTime = 1f;
	private float timer;
	private Slider mySlider;
	private bool gazeAt;
	float distance;
	private Coroutine fillBarRoutine;
	// Use this for initialization
	void Start () {
		mySlider = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Slider> ();
		if (mySlider == null) {
		}
	}
	void Update(){
		distance = Vector3.Distance (transform.position, Camera.main.transform.position);
	}
	public void PointerEnter(){
		if (distance < 1.5f) {
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
		if (gameObject.tag == "Firewood") {
			GameObject.Find ("Manager").GetComponent<PickUpManager>().IncFirewoodRPC ();
		}
		if (gameObject.tag == "Food") {
			GameObject.Find ("Manager").GetComponent<PickUpManager>().IncFoodRPC ();
		}

		GameObject.Find ("GvrMain").GetComponent<FollowPlayer> ().PlaySound ();
		photonView.RPC("DestroyObject", PhotonTargets.All);

	}
	[PunRPC]
	public void DestroyObject(){
		Destroy (gameObject);
	}
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
	}
}
