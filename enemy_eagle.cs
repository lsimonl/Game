using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_eagle : MonoBehaviour
{

    private Rigidbody2D rb;
    private Collider2D coll;
    public float speed;
    private float TopY, BottomY;
    public Transform top, bottom;
    private bool isUp;
    public float blood = 120;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        TopY = top.position.y;
        BottomY = bottom.position.y;
        Destroy(top.gameObject);
        Destroy(bottom.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        eagle_movement();
    }

    void eagle_movement()
    {
        if (isUp)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);

            if(transform.position.y > TopY)
            {
                isUp = false;
                
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if(transform.position.y < BottomY)
            {
                isUp = true;
            }
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Debug.Log("hurting............");
            blood -= 25;
            if (blood <= 0)
            {
                anim.SetBool("death", true);
                Destroy(gameObject, 0.5f);
            }
        }

    }
}
