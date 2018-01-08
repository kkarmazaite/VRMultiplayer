using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkPlayer : Photon.MonoBehaviour {
	bool isAlive= true;
	//public Text playerName;
	string playerName="Player";
	private GameManager gameManager;
	Vector3 position;
	Quaternion rotation;
	float lerpSmoothing=10f;
	//GameObject myCamera;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		playerName = gameManager.PlayerName;
		PhotonNetwork.player.NickName = playerName;
		this.GetComponentInChildren<TextMesh> ().text = GetComponent<PhotonView> ().owner.NickName;
		if (PhotonNetwork.player.IsMasterClient) {
			GameObject.Find ("Manager").GetComponent<PickUpManager> ().Instantiate ();
		}
		//playerName.text = gameManager.PlayerName;
		if (photonView.isMine) {
			
			//myCamera = GameObject.Find ("GvrMain");
			//myCamera.SetActive (true);
			gameObject.name="Me";
			GetComponent<Movement> ().enabled = true;
			GetComponent<Rigidbody> ().useGravity = true;
			this.gameObject.transform.Find("PlayerBody").gameObject.SetActive(false);
			this.gameObject.transform.Find("PlayerHead").gameObject.SetActive(true);
			this.GetComponentInChildren<TextMesh> ().gameObject.SetActive(false);
			//playerName.gameObject.SetActive (false);
			//body.GetComponent<Rigidbody> ().useGravity = true;
		}else{
			GetComponent<Animator> ().enabled = true;
			this.gameObject.transform.Find("PlayerMenuCanvas").gameObject.SetActive(false);
			this.gameObject.transform.Find("Tutorial").gameObject.SetActive(false);
			gameObject.name="Network Player";
			StartCoroutine ("Alive");
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if (stream.isWriting) {
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
		} else {
			position=(Vector3)stream.ReceiveNext();
			rotation=(Quaternion)stream.ReceiveNext();
		}
	}
	IEnumerator Alive(){
		while (isAlive) {
			transform.position = Vector3.Lerp (transform.position, position, Time.deltaTime*lerpSmoothing);
			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime * lerpSmoothing);
			yield return null;
		}
	}
}
