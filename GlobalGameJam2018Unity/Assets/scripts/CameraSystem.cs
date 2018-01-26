using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    private GameObject player;
    public float xMin, xMax;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        gameObject.transform.position = new Vector3(x, 5, gameObject.transform.position.z);
	}
}
