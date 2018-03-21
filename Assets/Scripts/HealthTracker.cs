using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour {
	
	private Text myHealth;
	
	// Use this for initialization
	void Start () {
		myHealth = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		myHealth.text = PlayerController.health.ToString();
		if (PlayerController.health <= 0){
			myHealth.text = "0";
		}
	}

	
}
