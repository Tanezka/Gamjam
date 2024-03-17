using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public counter script;
    public  int scene;
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player" && script.count == script.total)
            SceneManager.LoadScene(scene);
    }
}
