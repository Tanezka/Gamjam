using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public float x = 10;
    public float y = 7;

    public float z = 25;

    public GameObject obj;

    float   y_axis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.activeSelf == true)
            gameObject.transform.position = new Vector3(obj.transform.position.x + x, obj.transform.position.y + y, obj.transform.position.z - z);
    }
}
