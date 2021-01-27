using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer sprite;
    private CircleCollider2D circle;
    public GameObject collected;
    public int score;
    private AudioSource som;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();    
        som = GetComponent<AudioSource>(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            som.Play();
            sprite.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            Score.pontos += score;
            Controller.instance.totalScore += score;
            Controller.instance.UpdateScoreText();

            Destroy(gameObject, 0.25f);
        }
    }
}
