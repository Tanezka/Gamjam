using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    GameObject   pform;
    bool                flag = true;
    public float        start = 10;
    public float        finish = 10;
    public float        time = 10;

    // Start is called before the first frame update
    void Start()
    {
        pform = gameObject;
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
        LeanTween.moveX(pform, finish, time).setOnComplete(move_platform_right);
    }

    void    move_platform_right()
    {
        LeanTween.moveX(pform, start, time).setOnComplete(move_platform_left);
    }

}
