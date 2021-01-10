using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purple : MonoBehaviour
{
    public GameObject dialop_P1;
    public GameObject dialop_P2;
    public float count = 1;
    private Rigidbody2D rb;
    private Collider2D coll;
    public float speed = 20;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }


    void Update()
    {   

        run();

    }

    void run()
    {   
        if(gameObject.transform.position.x < 80)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            gameObject.transform.position = new Vector2(80f,0f);
            gameObject.transform.localScale = new Vector2(-0.3f,0.3f);
            anim.enabled = false;
        }
       
    }


    void close_Dialog()
    {
        dialop_P1.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coll.enabled = false;
            dialop_P1.SetActive(true);
        }
        if (collision.gameObject.tag == "Wall" )
        {
            gameObject.transform.position = new Vector2(80f, 0f);

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coll.enabled = true;
            Invoke("close_Dialog", 2f);
        }
    }
}
