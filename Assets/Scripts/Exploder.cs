using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour {

	public AudioClip shipExplosionSFX;
	public GameObject explosionPrefab;

	public void Explode(Vector3 explosionPosition){
		var explosionInstance = Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
		var particleSystem = explosionInstance.GetComponent<ParticleSystem>();
        particleSystem.Play();
		AudioSource.PlayClipAtPoint(shipExplosionSFX, explosionPosition);
	}
}
