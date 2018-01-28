using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField]
    public string vl = "";
    [SerializeField]
    private bool activeable = false;
    [SerializeField]
    private bool active = false;


    // Use this for initialization
    void Start()
    {
        Activation();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activation()
    {
        gameObject.GetComponent<Collider2D>().enabled = active;
    }


    public string GetVL()
    {
        return vl;
    }

    public bool GetActive()
    {
        return active;
    }

    public bool GetActiveable()
    {
        return activeable;
    }

    public void SetActive(bool sa)
    {
        active = sa;
    }


}
