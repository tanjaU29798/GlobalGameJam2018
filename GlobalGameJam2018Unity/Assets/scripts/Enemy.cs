using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	[SerializeField] private float speed = 1.0f; //move speed
	private Vector3 playerPosition; //Position des Spielers
	private Rigidbody2D rb; //RB des Gegeners
	private float moveHorizontal; //Bewegung Horizontal


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update () {
        print("hi");
        print("hi zurueck");
		playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		if (rb.position.x < playerPosition.x) {
			move (speed);
		} else if (rb.position.x > playerPosition.x) {
			move (-speed);
		} else {
			move (0);
		}
	}

	//Dem Spieler hinther gehen
	void move(float x){
		Vector2 movement = new Vector2 (speed, 0.0f);
		rb.velocity = movement * Time.deltaTime;
	}

}
