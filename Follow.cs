using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Transform position_player;
    private Rigidbody2D v_player;
    public Rigidbody2D rb;
    public float posX;
    public float posY;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }

    void follow()
    {
        position_player = GameObject.Find("player").GetComponent<Transform>();
        v_player = GameObject.Find("player").GetComponent<Rigidbody2D>();

        posX = position_player.position.x - 3;
        posY = position_player.position.y;
        rb.position = new Vector2(posX, posY);

        float faceDirection = Input.GetAxis("Horizontal");

        //purple 脸部朝向
        if (faceDirection == -1)
        {
            gameObject.transform.localScale = new Vector2(faceDirection * 0.3f,0.3f);
        }
        else
        {
            gameObject.transform.localScale = new Vector2(0.3f, 0.3f);

        }

        // purple动画切换
        if (Mathf.Abs(v_player.velocity.x) < 0.1f)
        {
            anim.SetBool("idle", true);

        }
        else
        {
            anim.SetBool("idle", false);
        }

    }
}
