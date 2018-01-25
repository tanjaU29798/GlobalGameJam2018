using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField] private float speed = 20.0f; //Geschwindigkeit des Spielers
	[SerializeField] private float jumpM = 10.0f; //Sprunghoehe

    private Rigidbody2D rb; //Rigidbody des Spielers
	private float moveHorizontal; //Bewegung Horizontal
	private bool jumpB = false; //Ist ein Sprung moeglich?
	private bool vulnerable = true; //Ist der Spieler verletzbar?
	[SerializeField] private float invulnerableTime = 0.5f; //Zeit in der der Spieler unverwundbar ist 

	[SerializeField] private int lives = 3; //Leben des Spielers

	public float restartDelay = 3f; //Zeit bis Game Restartet wird
	float restartTimer; //Zeitzähler bis Level neu startet

	private bool won=false; //Ziel erreicht

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (lives > 0) {
			move ();
			jump ();
			if (won) {
				print ("Won");
				restartTimer += Time.deltaTime;
				if (restartTimer >= restartDelay) {
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
			}
		// Wenn der Spieler kein Leben mehr hat, dann wird das Spiel kurz angehalten und startet mit dem gleichen Level erneut
		} else {
			print ("Gameover");
			restartTimer += Time.deltaTime;
			if (restartTimer >= restartDelay) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}

	// Bewegung
	void move(){
		moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (moveHorizontal * speed, 0.0f);
		rb.velocity = movement * Time.deltaTime;
	}

	//Einfacher Sprung
	void jump(){
		if (Input.GetButtonDown ("Jump") && jumpB == true) {
			Vector2 movement = new Vector2 (0.0f, jumpM);
			rb.AddForce (movement, ForceMode2D.Impulse);
		}
	}

	//Erste Kollision
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Ground") {
			jumpB = true;
		}
		//Wenn der Gegner berührt wird, dann verliert ein Leben
		if (coll.gameObject.tag == "Enemy" && vulnerable) {
			lives--;
			vulnerable = false;
			StartCoroutine(ResetVulnerable());
		}
		// Wenn das Ziel berührt wird, dann wird "won" auf true gesetzt
		if (coll.gameObject.tag == "Finish") {
			won = true;
		}
	}

	// Wenn Kollision verlassen wird
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "Ground") {
			jumpB = false;
		}
	}

    //Nach Zeitablauf ist der Spieler wieder verwundbar
	IEnumerator ResetVulnerable(){
		yield return new WaitForSecondsRealtime (invulnerableTime);
		vulnerable = true;
	}

}
