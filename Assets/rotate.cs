using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    int x;
    int y;
    int z;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-1, 1);
        y = Random.Range(-1, 1);
        z = Random.Range(-1, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(x, y, z);
    }
}
