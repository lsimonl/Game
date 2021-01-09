using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Frog : MonoBehaviour
{
    
    public float blood = 100;
    public Animator anim;
    public Collider2D coll;
    private Rigidbody2D rb;
    public Transform leftPoint, rightPoint;
    public LayerMask Ground;
    private bool faceLeft = true;
    public float speed, jumpForce;
    private float leftX, rightX;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       // transform.DetachChildren();
        leftX = leftPoint.position.x;
        rightX = rightPoint.position.x;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        enemy_anim_switch();
    }

    void enemy_Movement()
    {
        if (faceLeft)
        {
            if (coll.IsTouchingLayers(Ground))
            {
                anim.SetBool("jumping", true);
                rb.velocity = new Vector2(-speed, jumpForce);
            }
           

            if (transform.position.x < leftX)
            {
                faceLeft = false;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else{
            if (coll.IsTouchingLayers(Ground))
            {
                anim.SetBool("jumping", true);
                rb.velocity = new Vector2(speed, jumpForce);
            }
           
            if (transform.position.x > rightX)
            {
                faceLeft = true;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        
    }

    //伤害
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Debug.Log("hurting............");
            blood -= 25;
            if (blood <= 0)
            {
                anim.SetBool("death", true);
                Destroy(gameObject,0.5f);
            }
        }
       
    }
   
    //动画
    void enemy_anim_switch()
    {
        if (anim.GetBool("jumping"))
        {
            if(rb.velocity.y < 0.1)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("failing", true);
            }
        }
        if (coll.IsTouchingLayers(Ground) && anim.GetBool("failing"))
        {
            anim.SetBool("failing", false);
        }
    }
}
