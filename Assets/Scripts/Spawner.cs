using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject meteo1;
    public GameObject meteo2;
    public GameObject meteo3;
    public GameObject energy;
    public Transform spawnPoint;

    GameObject  obj;
    float   timer;
    float   second_timer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        int         num;
        
        num = Random.Range(0,3);
        if (num == 0)
            obj = meteo1;
        else if (num == 1)
            obj = meteo2;
        else if (num == 2)
            obj = meteo3;
        Instantiate(obj, spawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        second_timer += Time.deltaTime;
        if (timer > 1f)
        {
            SpawnObject();
            timer = 0;
        }
        if (Mathf.Round(second_timer) > 6)
        {
            Instantiate(energy, spawnPoint.position, Quaternion.identity);
            second_timer = 0;
        }     
    }
}
