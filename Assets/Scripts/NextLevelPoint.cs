using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPoint : MonoBehaviour
{
    public string nextStage;
    public bool finalStage;
    private int media;
    private AudioSource som;
    
    private void Start() 
    {
        som = GetComponent<AudioSource>();    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Score.pontos += Controller.instance.totalScore;                
            Destroy(Controller.instance.player.gameObject, 2f);
            nextStage = Controller.instance.nextLevel;
            media = Score.pontos;

            if(finalStage)
            {
                if(media > 350)
                {
                    SceneManager.LoadScene("Champion1");
                }
                else if(media > 300 )
                {
                    SceneManager.LoadScene("Champion2");
                }
                else if(media > 200)
                {
                    SceneManager.LoadScene("Champion3");
                }
                else
                {
                    SceneManager.LoadScene("Champion4");
                }
            }   
            else
            {
                SceneManager.LoadScene(nextStage);
            }
        }
    }
}