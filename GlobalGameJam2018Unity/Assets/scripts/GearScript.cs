using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearScript : MonoBehaviour {

    public Gearwheel[] gear;

	// Use this for initialization
	void Start () {
        gear = FindObjectsOfType<Gearwheel>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("4"))
            Activation("4");
        else if (Input.GetKeyDown("6"))
            Activation("6");
        else if (Input.GetKeyDown("8"))
            Activation("8");
   
    }

    private void Activation(string key)
    {
        foreach(Gearwheel g in gear)
        {
            if(g.GetVL() == key && g.GetActiveable())
            {
                bool gm = g.GetActive();
                g.SetActive(!gm);
                g.SetMove(true);
            }
            else if (g.GetVL() == key && !g.GetActiveable())
            {
                bool gm = g.GetMove();
                g.SetMove(!gm);
            }
            else if (g.GetActiveable())
            {
                g.SetActive(false);
                g.SetMove(false);
            }
            g.Activation();
            g.childrenActivation();
        }
    }
}
