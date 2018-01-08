using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpManager : Photon.MonoBehaviour {
	public GameObject FirewoodObj;
	public int StickCount;
	public int MushroomCount;
	public int FirewoodCount;
	public int FoodCount;
	private int FoodCount2;
	public int CollectedFirewood;
	public int CollectedFood;
	public bool fireLit;
	private Vector3 position;
	private Quaternion rotation;
	List<GameObject> MushroomList = new List<GameObject>();
	public GameObject Mushroom1;
	public GameObject Mushroom2;
	public GameObject Mushroom3;
	public GameObject winMenu;
	private LightFire fireplace;
	// Use this for initialization
	void Start () {
		MushroomList.Add(Mushroom1);
		MushroomList.Add(Mushroom2);
		MushroomList.Add(Mushroom3);
		FoodCount2 = FoodCount;
		fireLit = false;
		fireplace = GameObject.Find ("Fireplace").GetComponent<LightFire> ();
	}
	void Update () {
		if(PhotonNetwork.playerList.Length>0)
			FoodCount=FoodCount2*PhotonNetwork.playerList.Length;
		if (CollectedFirewood >= FirewoodCount) {
			fireplace.FirewoodCollected = true;
		}
		if (fireLit&&CollectedFood>=FoodCount) {
			GameObject.Find ("Tutorial").GetComponent<win> ().WinMenu ();

		}
	}
	[PunRPC]
	public void LitFireRPC(){
		photonView.RPC("LitFire", PhotonTargets.All);
	}
	[PunRPC]
	public void LitFire(){
		fireLit = true;
	}

	[PunRPC]
	public void Instantiate(){
		for (int i = 0; i < StickCount; i++) {
			photonView.RPC("RandomPosition", PhotonTargets.All);
			photonView.RPC("RandomRotation", PhotonTargets.All);
			PhotonNetwork.InstantiateSceneObject (FirewoodObj.name, position, rotation,0,null);
		}
		for (int i = 0; i < MushroomCount; i++) {
			photonView.RPC("RandomPosition", PhotonTargets.All);
			photonView.RPC("RandomRotation", PhotonTargets.All);
			PhotonNetwork.InstantiateSceneObject ((MushroomList[Random.Range(0,3)].name), position, rotation,0,null);
		}
	}
	[PunRPC]
	public void RandomPosition(){
		position = new Vector3 (Random.Range (-7, 7), -0.65f, Random.Range (-7, 7));
	}
	[PunRPC]
	public void RandomRotation(){
		rotation = Quaternion.Euler(0, Random.Range (0, 360), 0);
	}
	[PunRPC]
	public void IncFirewoodRPC(){
		photonView.RPC("IncFirewood", PhotonTargets.All);
	}
	[PunRPC]
	public void IncFoodRPC(){
		photonView.RPC("IncFood", PhotonTargets.All);
	}
	[PunRPC]
	public void IncFirewood(){
		CollectedFirewood++;
	}
	[PunRPC]
	public void IncFood(){
		CollectedFood++;
	}
		
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
	}

}

