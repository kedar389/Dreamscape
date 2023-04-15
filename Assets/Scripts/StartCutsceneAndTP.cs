using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartCutsceneAndTP : MonoBehaviour
{

    public Transform teleportLocation;
    private Collider2D coll;
    public VideoPlayer videoplayer;
    public Canvas platno;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        platno.enabled = false;
        videoplayer.loopPointReached += CheckOver;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Nightmare"))
        {
            //Start Cutscene surely
            videoplayer.enabled = true; // Enable the VideoPlayer component
            platno.enabled = true;
            videoplayer.Play();
            //TP Player
            col.gameObject.transform.position = teleportLocation.position;
            GetComponent<Collider2D>().enabled = false;
        }

    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        platno.enabled = false;
        Destroy(gameObject);
    }



    // Update is called once per frame
    void Update()
    {

    }
}
