using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	public GameObject FrontMenu, About, InternetError, LogIn, WinMenu;
	public Toggle VR;
	public Toggle Music;
	public Text PlayerName;
	public Text PlaceHolder; 
	private GameManager gameManager;
	void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		VR.isOn = !gameManager.VRMode; 
		Music.isOn = !gameManager.Music;
		if (gameManager.lostConnection) {
			Menu (4);
		} else {
			Menu (0);
		}
	}
	void Update(){
		if (VR.isOn) {
			gameManager.VRMode = false;
		} else {
			gameManager.VRMode = true;
		}
		if (Music.isOn) {
			gameManager.Music = false;
		} else {
			gameManager.Music = true;
		}

	}
	public void Menu(int n)
	{
		switch (n)
		{
		case 0:
			FrontMenu.SetActive (true);
			About.SetActive (false);
			InternetError.SetActive (false);
			LogIn.SetActive (false);
			WinMenu.SetActive (false);
			PlaceHolder.color = Color.yellow;
			break;
		case 1:
			FrontMenu.SetActive (false);
			LogIn.SetActive (true);
			break;
		case 11:
			if (Application.internetReachability == NetworkReachability.NotReachable) {
				LogIn.SetActive (false);
				InternetError.SetActive (true);
			} else {
				if (PlayerName.text != "") {
					gameManager.PlayerName = PlayerName.text;
					SceneManager.LoadScene ("Bakalaurinis");
				} else {
					PlaceHolder.color = Color.red;
				}
			}
			break;
		case 2:
			FrontMenu.SetActive (false);
			About.SetActive (true);
			break;
		case 3:
			Application.Quit();
			break;
		case 4:
			FrontMenu.SetActive (false);
			InternetError.SetActive (true);
			break;
		case 5:
			FrontMenu.SetActive (false);
			WinMenu.SetActive (true);
			break;
		}
	}
		
}
	

