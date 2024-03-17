using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back : MonoBehaviour
{
    float   pos_x;
    float   pos_z;
    float   pos_y;
    // Start is called before the first frame update
    void Start()
    {
        pos_x = transform.position.x;
        pos_z = transform.position.z;
        pos_y = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vec = new Vector3(pos_x, pos_y, pos_z);
        if (pos_y - 1 > -163)
        {
            pos_y -= 0.5f;
            transform.position = vec;
        }
        else
        {
            pos_y = 163;
            transform.position = vec;
        }
    }
}
