using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimentoPlayer : MonoBehaviour
{
    public float velocidade;
    public float jumpForce;
    public bool isJump;
    public bool doubleJump;
    public GameObject touchControl;
    public AudioSource soundOfJump;
    public AudioSource soundOfSaw;
    private Rigidbody2D rig;
    private Animator anim;
    private float movimento;

    private bool isBlowing;
    private bool moveRight;
    private bool moveLeft;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        soundOfJump = GetComponent<AudioSource>();
        soundOfSaw = GetComponent<AudioSource>();
        touchControl.SetActive(Control.isJoy);
    }
    void Update()
    {
        Move();
        Jump();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Controller.instance.Pause();
        }
    }
    void Move()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            Control.isJoy = false;
            touchControl.SetActive(Control.isJoy);
            movimento = Input.GetAxis("Horizontal");
            
        }
        else
        {
            if(moveRight)
            {
                movimento = 1f;
            }
            else if(moveLeft)
            {
                movimento = -1f;
            }
            else
            {
                movimento = 0;
            }
        }

        rig.velocity = new Vector2(movimento * velocidade, rig.velocity.y);
                
        if (movimento > 0f)
        {
            anim.SetBool("Corrida", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (movimento < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anim.SetBool("Corrida", true);
        }

        if (movimento == 0f)
        {
            anim.SetBool("Corrida", false);
        }
    }
    
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isBlowing)
        {
            touchControl.SetActive(false);
            FJump();
        }
    }

    public void RightRun(bool active)
    {
        moveRight = active;
    }

    public void LeftRun(bool active)
    {
        moveLeft = active;
    }

    public void FJump()
    {
        if(!isJump)
        {
            rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            doubleJump = true;
            anim.SetBool("Pulo", true);
            soundOfJump.Play();
        }       
        else
        {
            if (doubleJump)
            {
                rig.AddForce(new Vector2(0f, jumpForce/1.5f), ForceMode2D.Impulse);
                doubleJump = false; 
                soundOfJump.Play();
            }
        } 
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJump = false;
            anim.SetBool("Pulo", false);
        }

        if(collision.gameObject.tag == "Spike")
        {
            Controller.instance.GameOver();
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Saw")
        {
            Controller.instance.GameOver();
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "END")
        {
            anim.SetBool("Pulo", false);
            anim.SetBool("Corrida", false);
            moveLeft = false;
            moveRight = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJump = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Fan")
        {
            isBlowing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Fan")
        {
            isBlowing = false;
        }
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.layer == 8)
        {
            isJump = false;
            anim.SetBool("Pulo", false);
        }
    }
    /*
        Movimento Com "transform.position"
    void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Velocidade * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Velocidade * Time.deltaTime);
        }
    }
    */
}