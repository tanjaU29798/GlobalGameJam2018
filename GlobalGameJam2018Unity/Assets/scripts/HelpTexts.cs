using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpTexts : MonoBehaviour {

    [SerializeField]
    private int counter = 1000;
    private bool pressed6 = false;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("6")) pressed6 = true;

        if (!pressed6)
        {
            if (counter <= 0)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
            }
            else counter--;
        }
        
	}
}
