using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrevioiusLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(Controller.instance.player.gameObject, 2f);
            SceneManager.LoadScene(Controller.instance.previousLevel);
        }
    }
}
