using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gearwheel : MonoBehaviour
{

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
        gameObject.GetComponent<Renderer>().enabled = active;
        gameObject.GetComponent<Collider2D>().enabled = active;
    }

    // Update is called once per frame
    void Update()
    {
        if(activeable && Input.inputString == vl)
        {
            active = !active;
            gameObject.GetComponent<Renderer>().enabled = active;
            gameObject.GetComponent<Collider2D>().enabled = active;
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
                transform.Rotate(Vector3.back * 0.5f);
            }
            else
            {
                //rotate counterclockwise
                transform.Rotate(Vector3.forward * 0.5f);
            }
        }
    }

    public void Flip()
    {
        cw = !cw;
    }
}
