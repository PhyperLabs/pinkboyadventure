using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskMan : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    public AudioSource lose, win;
    public float speed;
    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;
    public bool colliding;
    // Start is called before the first frame update
    public LayerMask layer;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        win = GetComponent<AudioSource>();
        lose = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if(colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed = -speed;
        }
    }
    bool playerDestroyed;
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
        {
            float height = collisionInfo.contacts[0].point.y - headPoint.position.y;

            if(height > 0 && !playerDestroyed)
            {
                win.Play();
                collisionInfo.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("Morte");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.1f);
            }
            else
            {
                lose.Play();
                playerDestroyed = true;
                Controller.instance.GameOver();
                Destroy(collisionInfo.gameObject);
            }
        }
    }
}
