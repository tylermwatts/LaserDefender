using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	public float health = 150;
	public float projectileSpeed = 10f;
	public GameObject projectile;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;
	public AudioClip enemyFireSound;
	public AudioClip enemyDies;
	public GameObject player;
	

	private ScoreKeeper scoreKeeper;

	void Start(){
		scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
	}

	void Update(){
		var lifeTracker = GameObject.Find("LifeTracker").GetComponent<LifeTracker>();
		float probability = Time.deltaTime * shotsPerSecond;
		if (!lifeTracker.playerDead && Random.value < probability){
			Fire();
		}
	}

	void Fire(){
		GameObject missile = Instantiate<GameObject>(projectile, transform.position, Quaternion.identity);
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(enemyFireSound, transform.position);
	}
	void OnTriggerEnter2D(Collider2D collider){
			Projectile missile = collider.gameObject.GetComponent<Projectile>();
			if (missile){
				health -= missile.GetDamage();
				missile.Hit();
				if (health <= 0){
					Die();
				}
			}
		}
		void Die(){
			AudioSource.PlayClipAtPoint(enemyDies,transform.position);
			scoreKeeper.Score(scoreValue);
			var exploder = GameObject.FindObjectOfType<Exploder>();
			exploder.Explode(transform.position);
			Destroy(gameObject);
		}

}
