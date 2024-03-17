using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossarena : MonoBehaviour
{
    public GameObject[] coll;
    
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject obj in coll)
                obj.SetActive(true);
        }    
    }
}
