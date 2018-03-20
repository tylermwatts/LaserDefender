using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;
	public static int livesGiven = 1;
	public int scoreToGiveLife = 5000;

	private Text myScore;
	
	void Start(){
		myScore = GetComponent<Text>();
		Reset();
	}

	public void Score(int points){
		score += points;
		myScore.text = score.ToString();
		if (score >= scoreToGiveLife * livesGiven){
			LifeTracker.playerLives++;
			livesGiven++;
			var plusLifeFlash = FindObjectOfType<PlusLifeFlash>();
			plusLifeFlash.Flash();
		}
	}

	public static void Reset(){
		score = 0;
		livesGiven = 1;
		}
}