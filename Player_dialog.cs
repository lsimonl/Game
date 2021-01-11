using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_dialog : MonoBehaviour
{
    public GameObject dialog_F1;
    public GameObject dialog_P2;

    // Start is called before the first frame update
    void Start()
    {
        dialog_F1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("close_Dialog", 0.3f);
    }


    void close_Dialog()
    {
        dialog_F1.SetActive(false);
        
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "NextScene")
        {
            dialog_P2.SetActive(true);
            Invoke("NextMission", 0.6f);
          

        }
    }

    void NextMission()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
