using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public GameObject game;
    public GameObject gameDestroy;
    public Text texto;
    private string pontuacao;
    private AudioSource som;
    private void Start() 
    {
        som = GetComponent<AudioSource>();    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            som.Play();
            gameDestroy.SetActive(false);
            game.SetActive(true);
            pontuacao = Score.pontos.ToString();
            texto.text = pontuacao + "/400";
        }
    }
}
