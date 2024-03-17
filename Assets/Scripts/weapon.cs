using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject weap;
    public astronot_movement script;
    public AudioClip soundToPlay;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            weap.SetActive(true);
            if (audioSource != null)
                audioSource.PlayOneShot(soundToPlay);
            script.jump_strength = 25;
            script.max_speed = 15;
            Destroy(gameObject);
        }
    }
}
