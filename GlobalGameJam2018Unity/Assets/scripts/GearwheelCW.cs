using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearwheelCW : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //rotate clockwise
        transform.Rotate(Vector3.back * 0.5f);
    }
}
