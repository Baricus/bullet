using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Shooter
{
    public GameObject ball;
    //movement speed variables
    public float xVel;//vel meaning velocity
    public float yVel;

    int cooldowntime=0;

    Vector3 ActualMousePosition= new Vector3(0,0,0);
    //smoothing variable
    public float smoothTime;

    //current velocity
    private Vector2 velocity;

    //components
    private Rigidbody2D rb;

    public float firevelocity;

    // Start is called before the first frame update
    void Start()
    {
        //set up parameters
        rb = GetComponent<Rigidbody2D>();

        //zero's velocity
        velocity = Vector2.zero; 
    }

    //called at a fixed time interval
    void FixedUpdate()
    {
        //gets state of movement axis
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if (Input.GetAxis("FireL") > 0 && cooldowntime == 0)
        {
            Shoot();
        }
        rotate();

        //creates target movement vector
        Vector2 shift = new Vector2(horiz * xVel, vert * yVel);

        //updates the velocity vector to reach target position
        Vector2.SmoothDamp(rb.position, rb.position + shift, ref velocity, smoothTime, shift.magnitude);

        //moves rigidbody by velocity
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (cooldowntime> 0)
        {
            cooldowntime -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void Shoot()
    {
        if( Input.GetAxis("FireL")>0 && cooldowntime==0)
        {
           //translates the mouse's position to actual coordinates
            ActualMousePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
 
            //calculates the angle that the projectile will travel based on the player's location and the mouse's position
            float fireangle = Mathf.Atan2((ActualMousePosition.y-rb.position.y),(ActualMousePosition.x-rb.position.x));

            cooldowntime = 60;
            //fires the ball using the parent shooter's function shoot();
            shoot(fireangle,firevelocity,ball, transform.position);
        }


    }

    void rotate()
    {
        if (Input.GetAxis("RotateL") > 0)
        {
            transform.Rotate(Vector3.forward * 5);

        }
        if (Input.GetAxis("RotateR") > 0)
        {
            transform.Rotate(Vector3.forward * -5);

        }

    }
}
