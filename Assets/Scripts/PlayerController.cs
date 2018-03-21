using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 15.0f;
    public float padding = 0.5f;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 0.2f;
	public static float health = 250f;
	public LevelManager levelManager;
	public LifeTracker lifeTracker;
	public AudioClip fireSound;
	public AudioClip hitSound;
	public AudioClip shipExplosion;

	private bool freshRespawn;

    float xmin;
	float xmax;

	void Awake(){
		var playerBlink = GetComponent<Animation>();
        playerBlink.Play();
		freshRespawn = true;
		Invoke("ReadyToBeHit", 1f);
	}

    // Use this for initialization
    void Start () {
		// set Z position based on camera
		float distance = transform.position.z - Camera.main.transform.position.z;
		// these two vectors set the X boundaries of the playspace based on the camera
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3(1,0,distance));
		// setting variables for the X boundaries + padding for the player's ship
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	void Fire(){
			Vector3 offset = new Vector3(0, 1, 0);
			GameObject beam = Instantiate<GameObject>(projectile, transform.position+offset, Quaternion.identity);
			beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed,0);
			AudioSource.PlayClipAtPoint(fireSound,transform.position);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		RestrictToPlayspace();
	}

	public void OnTriggerEnter2D(Collider2D collider){
			Projectile missile = collider.gameObject.GetComponent<Projectile>();
			if (missile && !freshRespawn){
				health -= missile.GetDamage();
				missile.Hit();
				AudioSource.PlayClipAtPoint(hitSound, transform.position);
				FreshRespawn();
				if (health <= 0){
					PlayerDies();
				}
			}
		}

	void RestrictToPlayspace(){
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

	public void PlayerDies(){
		lifeTracker = GameObject.FindObjectOfType<LifeTracker>();
		lifeTracker.LoseLife();
		var exploder = GameObject.FindObjectOfType<Exploder>();
		exploder.Explode(transform.position);
		Destroy(gameObject);
	}

	void ReadyToBeHit(){
		freshRespawn = false;
	}

	void FreshRespawn(){
		var playerBlink = GetComponent<Animation>();
        playerBlink.Play();
		freshRespawn = true;
		Invoke("ReadyToBeHit", 1f);
	}
}