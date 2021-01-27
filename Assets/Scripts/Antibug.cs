using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antibug : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = new Vector2(transform.position.x, -1.7f);
        }
    }
}
