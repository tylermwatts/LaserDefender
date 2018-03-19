using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield1 : MonoBehaviour {

	static Starfield1 instance = null;
	
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		
	}
}
