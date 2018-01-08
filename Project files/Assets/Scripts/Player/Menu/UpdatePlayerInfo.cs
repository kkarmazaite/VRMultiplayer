using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerInfo : MonoBehaviour {
	public Text CollectedMushrooms, CollectedSticks;
	private PickUpManager PickUpManager;
	//private int FirewoodCount, FoodCount, CollectedFirewood,CollectedFood;
	// Use this for initialization
	void Start () {
		PickUpManager = GameObject.Find ("Manager").GetComponent<PickUpManager> ();
		CollectedMushrooms.text = PickUpManager.CollectedFood + "/" + PickUpManager.FoodCount;
		CollectedSticks.text = PickUpManager.CollectedFirewood + "/" +PickUpManager.FirewoodCount;

	}

	// Update is called once per frame
	void Update () {
		CollectedMushrooms.text = PickUpManager.CollectedFood + "/" + PickUpManager.FoodCount;
		CollectedSticks.text = PickUpManager.CollectedFirewood + "/" +PickUpManager.FirewoodCount;
	}


}
