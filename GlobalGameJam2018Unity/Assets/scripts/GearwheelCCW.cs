using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearwheelCCW : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //rotate counterclockwise
        transform.Rotate(Vector3.forward * 0.5f);
    }
}
