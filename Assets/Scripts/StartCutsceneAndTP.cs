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
	public GameObject me;
	GameObject targetObject;
	GameObject targetObjectSanity;
	BackgroundMusicController targetScript;
	LoseSanity targetScriptSanity;

	// Start is called before the first frame update
	void Start()
    {

        coll = GetComponent<Collider2D>();
        platno.enabled = false;
		
			videoplayer.loopPointReached += CheckOver;
			targetObject = GameObject.Find("BackgroundMusic");
			targetScript = targetObject.GetComponent<BackgroundMusicController>();
			targetObjectSanity = GameObject.Find("Nightmare player");
			targetScriptSanity = targetObjectSanity.GetComponent<LoseSanity>();
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Nightmare"))
        {	
			if (me.name == "Guitar")
            {
                videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "Cutscene2");
                targetScriptSanity.inDream = true;
            }
            else if (me.name == "FamilyPhoto")
            {
                videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "Cutscene4");
				targetScriptSanity.inDream = true;
			}
            else if (me.name == "notebook")
            {
                videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "Cutscene6");
				targetScriptSanity.inDream = true;
			}
			else if (me.name == "guitar1")
			{
				videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "Cutscene3");
				targetScriptSanity.inDream = true;
			}
			else if (me.name == "photo1")
			{
				videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "Cutscene5");
				targetScriptSanity.inDream = true;
			}
			else if (me.name == "notebook1")
			{
				videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "Cutscene7");
				targetScriptSanity.inDream = true;
			}
			else if (me.name == "end")
			{
				videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "EndCutscene");
				targetScriptSanity.inDream = true;
			}
			else
            {
				videoplayer.clip = Resources.Load<VideoClip>("Videos/" + "StartCutscene");
				targetScriptSanity.inDream = true;
			}
			targetScript.onOff();
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

		if (vp.clip.name  == "Cutscene2")
		{
			targetScript.SetSong("Music/dream1");
			Destroy(GameObject.Find("Guitar"));
		}
		else if (vp.clip.name  == "Cutscene4")
		{
			targetScript.SetSong("Music/dream2");
			Destroy(GameObject.Find("FamilyPhoto"));
		}
		else if (vp.clip.name  == "Cutscene6")
		{
			targetScript.SetSong("Music/dream3");
			Destroy(GameObject.Find("notebook"));
		}
		else if (vp.clip.name == "Cutscene3")
		{
			targetScript.SetSong("Music/nightmare_music");
			Destroy(GameObject.Find("guitar1"));
		}
		else if (vp.clip.name  == "Cutscene5")
		{
			targetScript.SetSong("Music/nightmare_music");
			Destroy(GameObject.Find("photo1"));
		}
		else if (vp.clip.name  == "Cutscene7")
		{
			targetScript.SetSong("Music/nightmare_music");
			Destroy(GameObject.Find("notebook1"));
		}
		else if (vp.clip.name  == "EndCutscene")
		{
			Destroy(GameObject.Find("end"));
			Application.Quit();
		}
		else if (vp.clip.name == "StartCutscene")
		{
			targetScript.SetSong("Music/nightmare_music");
			Destroy(GameObject.Find("StartingCutscenePoint"));
		}
		
	}



	// Update is called once per frame
	void Update()
	{ }
}
