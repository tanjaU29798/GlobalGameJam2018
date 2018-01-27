using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gearwheel : MonoBehaviour
{

    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private bool cw = true;
    [SerializeField]
    private bool move = false;
    [SerializeField]
    private string vl = "";
    [SerializeField]
    private bool activeable = false;
    [SerializeField]
    private bool active = false;


    // Use this for initialization
    void Start()
    {
        childrenActivation();
        Activation();
    }

    // Update is called once per frame
    void Update()
    {
        if(activeable && Input.inputString == vl)
        {
            active = !active;
            childrenActivation();
            Activation();
        }
        //changen effect if button is clicke
        if (Input.inputString == vl)
        {
            if (vl == "4" || vl == "6" || vl == "8")
            {
                move = !move;
            }
        }
        if (move)
        {
            if (cw)
            {
                //rotate clockwise
                transform.Rotate(Vector3.back * speed);
            }
            else
            {
                //rotate counterclockwise
                transform.Rotate(Vector3.forward * speed);
            }
        }
    }

    private void Activation()
    {
        gameObject.GetComponent<Renderer>().enabled = active;
        gameObject.GetComponent<Collider2D>().enabled = active;
    }

    private void childrenActivation()
    {
        foreach (Transform child in transform)
            child.GetComponent<Renderer>().enabled = active;
    }

    public void Flip()
    {
        cw = !cw;
    }
}
