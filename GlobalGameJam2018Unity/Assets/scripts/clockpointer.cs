using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class clockpointer : MonoBehaviour
{

    private bool won = false;
    private bool move;
    private float restartTimer;
    public float restartDelay = 3f; //Zeit bis Game Restartet wird
    private GameObject[] end;

    // Use this for initialization
    void Start()
    {
        end = GameObject.FindGameObjectsWithTag("End");
        foreach(GameObject g in end)
        {
            g.GetComponent<Renderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.Rotate(Vector3.back * 0.2f);
            print("Won");
        }
        if (won)
        {
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            move = true;
            StartCoroutine(WaitWinning());
        }
    }

    IEnumerator WaitWinning()
    {
        foreach (GameObject g in end)
        {
            g.GetComponent<Renderer>().enabled = true;
        }
        yield return new WaitForSecondsRealtime(0.5f);
        won = true;
    }

}
