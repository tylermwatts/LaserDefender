using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTracker : MonoBehaviour {
public static int playerLives = 3;
public GameObject playerShipPrefab;
private Vector3 startPosition;
private GameObject playerShipInstance;
public AudioClip shipExplosionSFX;
public GameObject explosionPrefab;
public bool playerDead;

private Text myLives;
	
	void Start(){
		myLives = GetComponent<Text>();
		ResetLives();
	}

	void Update(){
		myLives.text = playerLives.ToString();
	}

	public void LoseLife(){
		playerDead = true;
		playerLives--;		
		if(playerLives <= 0){
			Invoke("YaFuckinLostPal", 1.5f);
		} else {
		Invoke("Respawn", 2f);
		}
	}

	public static void ResetLives(){
		playerLives = 3;
		}

	void YaFuckinLostPal(){
		var levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("Lose Screen");
	}
	
	void Respawn(){
		playerDead = false;
		var playerRespawner = GameObject.FindObjectOfType<PlayerRespawner>();
		playerRespawner.RespawnPlayer();
		}
}
