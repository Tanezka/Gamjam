using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject laser;
    public GameObject player;
    Quaternion myRotation;

    public AudioClip soundToPlay;
    public AudioSource audioSource;
    float   cooldown = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        myRotation.eulerAngles = player.transform.rotation.eulerAngles;
        if (Input.GetKeyDown(KeyCode.Space) && cooldown > 1)
        {
                Instantiate(laser, transform.position, myRotation);
                audioSource.PlayOneShot(soundToPlay);
                cooldown = 0;
        }
    }
}
