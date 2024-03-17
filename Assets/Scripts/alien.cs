using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{
    GameObject   pform;
    bool                flag = true;
    public float        start = 10;
    public float        finish = 10;
    public float        time = 10;
    public GameObject[] coll;
    public int          health = 5;

    // Start is called before the first frame update
    void Start()
    {
        pform = gameObject;
        transform.Rotate(0, 180, 0);
    }

    void    Update()
    {
        if (gameObject.activeSelf == true && flag)
        {
            move_platform_left();
            flag = false;
        }
    }

    void    move_platform_left()
    {
        transform.Rotate(0, 180, 0);
        LeanTween.moveX(pform, finish, time).setOnComplete(move_platform_right);
    }

    void    move_platform_right()
    {
        transform.Rotate(0, 180, 0);
        LeanTween.moveX(pform, start, time).setOnComplete(move_platform_left);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "laser")
        {
            health--;
            Destroy(other.gameObject);
            if (health == 0)
            {
                foreach (GameObject obj in coll)
                    obj.SetActive(false);
                Destroy(gameObject);
            }
        }   
    }
}