using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Control : MonoBehaviour
{
    public static AudioClip fireSound;
    static AudioSource audioSrc;
    void Start()
    {
        fireSound = Resources.Load<AudioClip>("GunShot4");
      
        audioSrc = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "GunShot4":
                audioSrc.PlayOneShot(fireSound);
                break;
        }
    }
}
