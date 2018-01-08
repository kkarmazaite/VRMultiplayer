using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	const string VERSION="v0.0.1";
	public string roomName="VVR";
	public string playerPrefabName="Player";
	public Transform spawnPoint;
	private Vector3 spawnPointOffset;
	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings(VERSION);
	}
	void OnJoinedLobby(){
		RoomOptions roomOptions = new RoomOptions() { IsVisible = false, MaxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom(){
		spawnPointOffset = new Vector3 (1 * PhotonNetwork.countOfPlayers, 0, 1 * PhotonNetwork.countOfPlayers);
		PhotonNetwork.Instantiate (playerPrefabName, spawnPoint.position+spawnPointOffset, spawnPoint.rotation, 0);
	}


}
