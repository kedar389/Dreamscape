using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(3);//Nightmare id in Build settings
    }

    public void Quit()
    {
        Application.Quit();        
    }
}
