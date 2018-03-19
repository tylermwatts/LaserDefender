using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield2 : MonoBehaviour {

	static Starfield2 instance = null;
	
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		
	}
}
