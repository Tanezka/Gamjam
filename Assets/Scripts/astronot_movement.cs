using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astronot_movement : MonoBehaviour
{
    Rigidbody   body;
    public float    stop_time = 0.5f;
    public float    max_speed = 15;
    public float    jump_strength = 18;
    public float    gravity;
    public float    movement_force_constant = 1000;
    bool            is_ground;
    public Animator animator;

    private bool isCollidingWithPlatform = false;
    Transform platform;

    public GameObject[] objectsToDeactivate;
    void    move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            body.velocity = new Vector3(-max_speed, body.velocity.y, body.velocity.z);
            animator.SetBool("iswalking", true);
            if (transform.rotation.eulerAngles.y == 90)
                transform.Rotate(0, -180, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            body.velocity = new Vector3(max_speed, body.velocity.y, body.velocity.z);
            if (transform.rotation.eulerAngles.y == 270)
                transform.Rotate(0, 180, 0);
            animator.SetBool("iswalking", true);
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && is_ground == true)
        {
            body.velocity = new Vector3(body.velocity.x, jump_strength, body.velocity.z);
            animator.SetBool("inair", true);
            is_ground = false;
        }
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) && body.velocity.x < 0)
        {
            body.velocity = new Vector3(0, body.velocity.y, body.velocity.z);
            animator.SetBool("iswalking", false);

        }
        if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) && body.velocity.x > 0)
        {
            body.velocity = new Vector3(0, body.velocity.y, body.velocity.z);
            animator.SetBool("iswalking", false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Movement start");
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        body.velocity = new Vector3(body.velocity.x, body.velocity.y - (gravity * Time.deltaTime), body.velocity.z);
    }

    void FixedUpdate()
    {
        if (isCollidingWithPlatform)
        {
            // Move the character with the platform
            Vector3 platformMovement = platform.position - platform.GetComponent<Rigidbody>().position;
            transform.position += platformMovement;
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "moving")
        {
            is_ground = true;
            animator.SetBool("inair", false);
            animator.SetBool("atground", true);
        }
        if (other.gameObject.tag == "moving")
        {
            isCollidingWithPlatform = true;
            platform = other.transform;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "moving")
        {
            isCollidingWithPlatform = false;
        }
    } 

    void    OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Button")
        {
            foreach (GameObject obj in objectsToDeactivate)
                    obj.SetActive(true);
        }
        if (other.gameObject.tag == "Jump")
        {
            jump_strength = 36;
            max_speed = 15;
            Destroy(other.gameObject);
        }
    }
}
