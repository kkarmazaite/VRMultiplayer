using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenuManager : MonoBehaviour {
	public GameObject PlayerInfo, FrontMenu, HelpMenu, LogOffMenu, PlayerMenu, MenuIcon;
	public void Menu(int n)
	{
		switch (n)
		{
		case 0:
			PlayerInfo.SetActive (true);
			FrontMenu.SetActive (true);
			HelpMenu.SetActive (false);
			LogOffMenu.SetActive (false);
			break;
		case 1:
			PlayerInfo.SetActive (false);
			FrontMenu.SetActive (false);
			HelpMenu.SetActive(true);
			break;
		case 2:
			PlayerInfo.SetActive (false);
			FrontMenu.SetActive (false);
			LogOffMenu.SetActive(true);
			break;
		case 3:
			PlayerMenu.SetActive (true);
			PlayerInfo.SetActive (true);
			FrontMenu.SetActive (true);
			HelpMenu.SetActive (false);
			LogOffMenu.SetActive (false);
			MenuIcon.SetActive (false);
			GameObject.Find ("Me").GetComponent<Movement> ().Position (true);

			break;
		case 4:
			GameObject.Find ("Me").GetComponent<Movement> ().Position (false);
			PlayerMenu.SetActive (false);
			MenuIcon.SetActive(true);
			break;
		case 5:
			StartCoroutine (Disconnect());
			break;
		}
	}
	IEnumerator Disconnect()
	{
		PhotonNetwork.Disconnect ();
		while (PhotonNetwork.connected)
			yield return null;
		SceneManager.LoadScene ("Menu");
		
	}
}
