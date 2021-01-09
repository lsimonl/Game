using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : MonoBehaviour
{
    private Rigidbody2D rb;//需要拖拽unity里的刚体到script
    private Animator anim; //动画器对象
    public LayerMask ground; //地面
    public Collider2D coll; //获取碰撞
    public float speed ;
    public float jump;
    public int cherry = 0;
    public int gem = 0;
    public Text CherryNumber;
    //public bool notHurt = true;
    


    // Start is called before the first frame update
    void Start()
    {
        //像刚体或动画器不需要声明公有变量，在start时获取即可
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (notHurt)
        //{
            Move();
        //}

        SwitchAnim();
    }

    private void Move()
    {
        float horizontal_move = Input.GetAxis("Horizontal");  // -1到0到1，乘以speed实现移动
        float vertical_move = Input.GetAxis("Vertical"); 
        float facedirection = Input.GetAxisRaw("Horizontal"); // 值为 0，-1，1
       
        //角色移动
        if(horizontal_move != 0){
            rb.velocity = new Vector2(horizontal_move * speed , rb.velocity.y);  // * Time.deltaTime
            anim.SetFloat("running", Mathf.Abs(facedirection));  //通过facedirection的值判断是不是在跑步
        }

        if (vertical_move != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical_move * speed ); // * Time.deltaTime
        }
        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
            //transform.Rotate(0f, 180f, 0f);
        }
        //角色跳跃
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump); //* Time.deltaTime
            anim.SetBool("jumping", true);
        }
    }

    void SwitchAnim() 
    {
        anim.SetBool("idle", false);

        if(rb.velocity.y < 0.1f && !coll.IsTouchingLayers(ground))
        {   //下降 同样是跳跃动作
            anim.SetBool("failing", true);
        }
        if (anim.GetBool("jumping"))
        {   //如果有跳跃动作
            if (rb.velocity.y < 0) //对y轴速度小于0时，下降开始
            {

                anim.SetBool("jumping", false);
                anim.SetBool("failing", true);
            }
        }
        //else if (!notHurt)
        //{
        //    if(Mathf.Abs(rb.velocity.x ) < 0.1)
        //    {
        //        notHurt = true;
        //    }
        //}

        else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("failing", false);
            anim.SetBool("idle", true);
        }
    }

    //收集物品
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "collection" )
        {
            cherry += 1;
            CherryNumber.text = cherry.ToString();
          
            Destroy(collision.gameObject);
            
        }
    }

    //消灭enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("colide with enemy");
            if (anim.GetBool("failing"))
            {
                Debug.Log(anim.GetBool("failing"));
                Destroy(collision.gameObject);
                rb.velocity = new Vector2(rb.velocity.x, 10);
                anim.SetBool("jumping", true);
            }
           
        }
        //else if (transform.position.x < collision.gameObject.transform.position.x)
        //{
        //    Debug.Log("受伤");
        //    rb.velocity = new Vector2(-5, rb.velocity.y);
        //    notHurt = false;
        //}
        //else if (transform.position.x > collision.gameObject.transform.position.x)
        //{
        //    rb.velocity = new Vector2(5, rb.velocity.y);
        //    notHurt = false;
        //}
    }
}
