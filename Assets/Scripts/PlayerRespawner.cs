using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour {

public GameObject playerShipPrefab;
private Vector3 startPosition;
private GameObject playerShipInstance;


	// Use this for initialization
	void Start () {
		playerShipInstance = GameObject.Find("Player");
		startPosition = playerShipInstance.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer(){
		playerShipInstance = Instantiate(playerShipPrefab, startPosition, Quaternion.identity);
	}
}
