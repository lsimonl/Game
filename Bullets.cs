using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float velx = 5f;
    public float vely = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {

        rb.velocity = new Vector2(velx, vely);
        Destroy(gameObject, 3f);
         
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
