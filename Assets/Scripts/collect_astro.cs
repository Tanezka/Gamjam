using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collect_astro : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip collect_sound;
    public AudioSource audioSource;
    public counter script;

    void    Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Collectibles")
        {            
            audioSource.PlayOneShot(collect_sound);
            script.count++;
            Destroy(other.gameObject);
        }
    }
}
