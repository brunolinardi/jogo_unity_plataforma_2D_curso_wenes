using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Animator anim;
    public float jumpForce;
    public bool isUp;
    public int health = 5;

    void Update()
    {
        if(health <= 0)
        {
            //destruo a caixa que é objeto pai
            anim.SetTrigger("break");
            Destroy(transform.parent.gameObject, 0.3f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) //collision já retorna o player
    {
        if(collision.gameObject.tag == "Player")
        {
            if(isUp)
            {
                anim.SetTrigger("hit");
                health--;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
            else
            {
                anim.SetTrigger("hit");
                health--;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
            }
        }
    }
}
