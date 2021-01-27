using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public float moveTime;
    
    public bool dirRightOrUp;
    public bool dirVert;
    public AudioSource som;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        som = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dirVert)
        {
            if(dirRightOrUp)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }

            timer += Time.deltaTime;

            if(timer >= moveTime)
            {
                dirRightOrUp = !dirRightOrUp;
                timer = 0f;
            }
        }
        else
        {
            if(dirRightOrUp)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            timer += Time.deltaTime;

            if(timer >= moveTime)
            {
                dirRightOrUp = !dirRightOrUp;
                timer = 0f;
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
        {
            som.Play();
        }
    }
}
