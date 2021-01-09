using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog1 : MonoBehaviour
{
    public GameObject EnterDialog;
    public GameObject dropWeapon;
    private float count = 0;
 
    

    private void Update()
    {
        if (GameObject.Find("player").GetComponent<Grab_controller>().Grabbled)
        {
            EnterDialog.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            EnterDialog.SetActive(true);
            dropWeapon.SetActive(true);
            
        }
        count += 1;
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        EnterDialog.SetActive(false);
         
    //    }
    //}

    
}
