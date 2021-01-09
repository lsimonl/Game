using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grab_controller : MonoBehaviour
{
    
    public float distance = 2f; //射线长度
    public bool Grabbled;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwforce;
    public LayerMask notGrabbled;
    private Rigidbody2D rb;

    public GameObject bulletRight, bulletLeft;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Pick_Throw();

    }

     void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }

    void Pick_Throw()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!Grabbled)
            {
                //grab
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);//激光射线

                if (hit.collider != null && hit.collider.tag == "guns")
                {
                    Grabbled = true;
                }

            }
            else if (!Physics2D.OverlapPoint(holdPoint.position, notGrabbled))
            {
                //throw
                Grabbled = false;
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1 * throwforce);
                   
                }
            }
        }

        if (Grabbled)
        {
            float direction = Input.GetAxisRaw("Horizontal"); // 值为 0，-1，1
            hit.collider.gameObject.transform.position = holdPoint.position;
           
            //武器方向调整
            if (direction != 0)
            {
                hit.collider.gameObject.transform.localScale = new Vector3(direction/20, hit.collider.gameObject.transform.localScale.y, hit.collider.gameObject.transform.localScale.z);
            }

            if (Input.GetMouseButton(0) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                fire();
                Audio_Control.PlaySound("GunShot4");
            }
        }
    }
    
    void fire()
    {
        bulletPos = transform.position;
        if(transform.localScale.x > 0)
        {   
            //子弹初始距离
            bulletPos += new Vector2(+5, 0);
            Instantiate(bulletRight, bulletPos, Quaternion.identity);
        }
        else if(transform.localScale.x < 0)
        {
            bulletPos += new Vector2( - 5,0);
            Instantiate(bulletLeft, bulletPos, Quaternion.identity);
        }
    }
}
