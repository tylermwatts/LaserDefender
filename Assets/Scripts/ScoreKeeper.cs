using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;
	private Text myScore;
	
	void Start(){
		myScore = GetComponent<Text>();
		Reset();
	}

	public void Score(int points){
		score += points;
		myScore.text = score.ToString();
	}

	public static void Reset(){
		score = 0;
		}
}