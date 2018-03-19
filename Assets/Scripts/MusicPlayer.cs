using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;

	private AudioSource music;
	
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
			SceneManager.sceneLoaded += OnSceneLoaded;
		}
		
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode){
		music.Stop();

		if (scene.buildIndex == 0){
			music.clip = startClip;
		}
		if (scene.buildIndex == 1){
			music.clip = gameClip;
		}
		if (scene.buildIndex == 2){
			music.clip = endClip;
		}
		music.loop = true;
		music.Play();
	}
}
