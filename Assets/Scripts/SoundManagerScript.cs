using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip beepSound, deathSound, hitSound, jumpSound, pointSound, winSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
 
        deathSound = Resources.Load<AudioClip>("death");
        hitSound = Resources.Load<AudioClip>("hit");
        jumpSound = Resources.Load<AudioClip>("jump");
        pointSound = Resources.Load<AudioClip>("point");
        winSound = Resources.Load<AudioClip>("win");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            
            case "death":
                audioSrc.PlayOneShot(deathSound);
                break;
            case "hit":
                audioSrc.PlayOneShot(hitSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "point":
                audioSrc.PlayOneShot(pointSound);
                break;
            case "win":
                audioSrc.PlayOneShot(winSound);
                break;
        }
    }
}
