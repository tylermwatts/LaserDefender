using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusLifeFlash : MonoBehaviour {

	// Use this for initialization
public void Flash(){
	var flashText = GetComponent<Animation>();
    flashText.Play();
	}

}
