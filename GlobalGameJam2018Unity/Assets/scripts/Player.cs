using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField] private float speed = 20.0f; //Geschwindigkeit des Spielers
	[SerializeField] private float jumpM = 10.0f; //Sprunghoehe

    private Rigidbody2D rb; //Rigidbody des Spielers
	private float moveHorizontal; //Bewegung Horizontal
	private bool jumpB = false; //Ist ein Sprung moeglich?
    public bool facingRight = true; //

	[SerializeField] private int lives = 3; //Leben des Spielers

	public float restartDelay = 3f; //Zeit bis Game Restartet wird
	float restartTimer; //Zeitzähler bis Level neu startet

	private bool won=false; //Ziel erreicht

    Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (lives > 0) {
			Move ();
			Jump ();
            Fall();
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
	void Move(){
        //Input
		moveHorizontal = Input.GetAxis ("Horizontal");
        if (moveHorizontal != 0) anim.SetInteger("speed", 1);
        else anim.SetInteger("speed", 0);

        //Player Direction
        if (moveHorizontal < 0.0f && facingRight) FlipPlayer();
        else if (moveHorizontal > 0.0f && !facingRight) FlipPlayer();

        //Move;
		rb.velocity = new Vector2(moveHorizontal * speed * Time.deltaTime, rb.velocity.y);
	}

	//Einfacher Sprung
	void Jump(){
		if (Input.GetButtonDown ("Jump") && jumpB == true) {
            rb.velocity = new Vector2(rb.velocity.x, jumpM);
            anim.SetInteger("jump", 1);
		}
        
	}

	//Erste Kollision
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Ground") {
			jumpB = true;
            anim.SetInteger("jump", -1);
        }
        if(coll.gameObject.tag == "Deathzone")
        {
            print("deathzone");
            lives--;
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

    IEnumerator land()
    {
        anim.SetInteger("jump", -1);
        yield return new WaitForSecondsRealtime(0.5f);
        anim.SetInteger("jump", 0);
    }

    private void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void Fall()
    {
        if (gameObject.transform.position.y < -2)
        {
            lives = 0;
        }
    }

}
