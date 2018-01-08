using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Photon.MonoBehaviour {
	public GameObject gvrMain;
	public Text FrameRate;
	public Text ping;
	public  float updateInterval = 0.5F;

	private float accum   = 0; // FPS accumulated over the interval
	private int   frames  = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval
	// Use this for initialization
	void Start () {
		timeleft = updateInterval; 
	}
	
	// Update is called once per frame
	void Update () {
		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;
		FrameRate.text=  "Frame Rate: " + Mathf.Round(accum/frames);
		//FrameRate.text= "Ping: " + Mathf.Round(1.0f/Time.deltaTime);
			ping.text= "Ping: " + PhotonNetwork.networkingPeer.RoundTripTime;
		}


}
