using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public static MusicController isso;
    public AudioSource backGroundSound;
    public AudioSource gameOverSound;
    public AudioSource championSound;
    public AudioSource mainMenuSound;
    public AudioSource creditsSound;
    // Play is called before the first frame update
    void Start()
    {
        isso = this;
        GameObject bgsObject = GameObject.Find("BGMusic");
        backGroundSound = bgsObject.GetComponent<AudioSource>();
        GameObject gosObject = GameObject.Find("GOMusic");
        gameOverSound = gosObject.GetComponent<AudioSource>();
        GameObject cpsObject = GameObject.Find("CPMusic");
        championSound = cpsObject.GetComponent<AudioSource>();
        GameObject mainObject = GameObject.Find("MainMusic");
        mainMenuSound = mainObject.GetComponent<AudioSource>();
        GameObject cdsObject = GameObject.Find("CDMusic");
        creditsSound = cdsObject.GetComponent<AudioSource>();
        
        string fase = Controller.instance.lvlName;
        if(fase == "mainMenu")
        {
            creditsSound.Stop();
            mainMenuSound.Play();
        }
        if(fase == "lvl_1")
        {
            mainMenuSound.Stop();
            backGroundSound.Play();
            gameOverSound.Stop();
        }
        if(fase == "Credits")
        {
            mainMenuSound.Stop();
            championSound.Stop();
            creditsSound.Play();
        }
        if(fase == "Champion")
        {
            backGroundSound.Stop();
            championSound.Play();
        }

        
    }
    public void Clean()
    {
        championSound.Stop();
        mainMenuSound.Stop();
        backGroundSound.Stop();
        creditsSound.Stop();
        gameOverSound.Stop();

    }
}
