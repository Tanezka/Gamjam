using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    Rigidbody   body;
    Vector3     velo;
    public float    stop_time;
    public float    max_speed;
    public float    movement_force_constant;
    float             count;
    private Scene _scene;


    void    x_axis()
    {
        float   num = 0;
        if (num == 0)
            num = body.velocity.x / stop_time;
        if (body.velocity.x > 0 && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
        {
            body.AddForce(Vector3.left * num );
            return ;
        }
        if (body.velocity.x < 0 && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
        {
            body.AddForce(Vector3.right * num * -1);
            return ;
        }
        num = 0;
    }

    void    y_axis()
    {
        float   num2 = 0;
        if (num2 == 0)
            num2 = body.velocity.y / stop_time;            

        if (body.velocity.y > 0 && !(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            body.AddForce(Vector3.down * num2);
            return ;
        }
        if (body.velocity.y < 0 && !(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            body.AddForce(Vector3.up * num2 * -1);
            return ;
        }
        num2 = 0;
    }
    void    release()
    {
        x_axis();
        y_axis();
    }
    void    move()
    {
        Debug.Log("speed y" + velo.y + "\n" + "speed x" + velo.x);
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && velo.x > -max_speed)
            body.AddForce(Vector3.left * movement_force_constant * Time.deltaTime);
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && velo.y < max_speed)
            body.AddForce(Vector3.up * movement_force_constant * Time.deltaTime);
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && velo.y > -max_speed)
            body.AddForce(Vector3.down * movement_force_constant * Time.deltaTime);
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && velo.x < max_speed)
            body.AddForce(Vector3.right * movement_force_constant * Time.deltaTime);
    }
    // Start is called before the first frame update

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }
    void Start()
    {
        Debug.Log("Movement start");
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > 30)
        {
            SceneManager.LoadScene(_scene.buildIndex + 1);
        }
        velo = body.velocity;
        move();
    }
    void FixedUpdate() 
    {
        release();    
    }

}
