using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	void Start(){
		var particleSystem = GetComponent<ParticleSystem>();
		Invoke("DestroyExplosion", particleSystem.main.duration);
	}

	private void DestroyExplosion(){
		Destroy(gameObject);
	}
	
}
