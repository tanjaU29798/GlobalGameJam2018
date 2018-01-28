using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearScript : MonoBehaviour {

    public Gearwheel[] gear;
    public DeathZone[] death;

	// Use this for initialization
	void Start () {
        gear = FindObjectsOfType<Gearwheel>();
        death = FindObjectsOfType<DeathZone>();
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
            }else if (g.GetVL() != key && g.GetVL() !="" && !g.GetActiveable())
            {
                g.SetMove(false);
            }
            g.Activation();
            g.childrenActivation();
        }
        foreach(DeathZone d in death)
        {
            if (d.GetVL() == key && d.GetActiveable())
            {
                bool gm = d.GetActive();
                d.SetActive(!gm);
            }
           /* else if (d.GetVL() == key && !d.GetActiveable())
            {
                bool gm = d.GetMove();
                d.SetMove(!gm);
            }*/
            else if (d.GetActiveable())
            {
                d.SetActive(false);
                //d.SetMove(false);
            }
            else if (d.GetVL() != key && d.GetVL() != "" && !d.GetActiveable())
            {
               // d.SetMove(false);
            }
            d.Activation();
        }
    }
}
