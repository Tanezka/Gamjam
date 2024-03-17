using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    Rigidbody   body;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-20, 30), transform.position.y, transform.position.z);
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector3(0, -10, 0);
        if (transform.position.y - 1 <= -30)
            Destroy(gameObject);
    }
}
