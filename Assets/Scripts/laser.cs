using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    // Start is called before the first frame update
    float   speed = 1;

    void    Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.rotation.eulerAngles.y == 270)
            speed = -1;
        transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
    }
}
