using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ExitDream : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform teleportLocation;
    private Collider2D coll;
    public VideoPlayer videoplayer;
    public Canvas platno;

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
            if (gameObject.name == "Exit_D1")
            {
                //videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "Cutscene2");
                GameObject targetObject = GameObject.FindGameObjectWithTag("notebook");
                Transform targetTransform = targetObject.transform;
                Vector3 targetPosition = targetTransform.position;                
                col.gameObject.transform.position = targetTransform.position;

            }
            else if (gameObject.name == "Exit_D2")
            {
                //videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "Cutscene4");
                GameObject targetObject = GameObject.FindGameObjectWithTag("notebook");
                Transform targetTransform = targetObject.transform;
                Vector3 targetPosition = targetTransform.position;
                col.gameObject.transform.position = targetTransform.position;

            }
            else if (gameObject.name == "Exit_D3")
            {
                //videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "Cutscene6");
                GameObject targetObject = GameObject.FindGameObjectWithTag("notebook");
                Transform targetTransform = targetObject.transform;
                Vector3 targetPosition = targetTransform.position;
                //Transform playerTransform = transform;
                //playerTransform.position = targetPosition;
                col.gameObject.transform.position = targetTransform.position;

            }
            else
            {
                videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "StartCutscene");
            }
            //Start Cutscene surely
            //videoplayer.enabled = true; // Enable the VideoPlayer component
            //platno.enabled = true;
            //videoplayer.Play();

            //TP Player

            //col.gameObject.transform.position = teleportLocation.position;
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
