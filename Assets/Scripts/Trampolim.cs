using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour
{
    public float jumpForce;
    private Animator animator;
    private Animator playerAnim;
    private AudioSource som;    
    void Start()
    {
        animator = GetComponent<Animator>();
        som = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
        {
            som.Play();
            playerAnim = collisionInfo.gameObject.GetComponent<Animator>();
            playerAnim.SetBool("Pulo", true);
            animator.SetTrigger("Jump");
            collisionInfo.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
