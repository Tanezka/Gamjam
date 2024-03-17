using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public Transform rect;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (rect.localScale.x - 60 > 0)
                rect.localScale = new Vector3(rect.localScale.x - 60, rect.localScale.y, rect.localScale.z);
            else
                rect.localScale = new Vector3(0, rect.localScale.y, rect.localScale.z);
        }
        if (other.gameObject.tag == "Collectable")
        {
            rect.localScale = new Vector3(300, rect.localScale.y, rect.localScale.z);            
            Destroy(other.gameObject);
        }
    }
}
