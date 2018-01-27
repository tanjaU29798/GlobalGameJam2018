using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gearwheel : MonoBehaviour
{

    [SerializeField]
    private bool cw = true;
    [SerializeField]
    private bool move = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
