using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class collect_astro : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip collect_sound;
    public AudioSource audioSource;
    public counter script;
    Scene scene;

    void    Awake()
    {
        scene = SceneManager.GetActiveScene();
    }
    void    Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(scene.buildIndex);
        }
        if (other.gameObject.tag == "Collectibles")
        {            
            audioSource.PlayOneShot(collect_sound);
            script.count++;
            Destroy(other.gameObject);
        }
    }
}
