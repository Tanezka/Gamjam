using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteo : MonoBehaviour
{
    Rigidbody   body;
    float   num;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-30, 40), transform.position.y, transform.position.z);
        body = GetComponent<Rigidbody>();
        num = Random.Range(-10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector3(num, -20, 0);
        if (transform.position.y - 1 <= -30)
            Destroy(gameObject);
    }
}
