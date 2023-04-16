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
        //Debug.Log(gameObject.name);
        if (col.gameObject.CompareTag("Nightmare"))
        {
            if (gameObject.name == "Guitar")
            {
                videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "Cutscene2");
            }
            else if (gameObject.name == "FamilyPhoto")
            {
                videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "Cutscene4");
            }
            else if (gameObject.name == "notebook")
            {
                videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "Cutscene6");
            }
            else
            {
				videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "StartCutscene");
			}
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
