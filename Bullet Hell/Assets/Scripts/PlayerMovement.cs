using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject ball;
    //movement speed variables
    public float xVel;//vel meaning velocity
    public float yVel;

    //smoothing variable
    public float smoothTime;

    //current velocity
    private Vector2 velocity;

    //components
    private Rigidbody2D rb;


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
        float horiz = Input.GetAxis("Horizontal");//will this allow me to get shoot input?
        float vert = Input.GetAxis("Vertical");

        Shoot();

        //creates target movement vector
        Vector2 shift = new Vector2(horiz * xVel, vert * yVel);

        //updates the velocity vector to reach target position
        Vector2.SmoothDamp(rb.position, rb.position + shift, ref velocity, smoothTime, shift.magnitude);

        //moves rigidbody by velocity
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void Shoot()
    {
        if( Input.GetAxis("FireL")>0)
        {
            Instantiate(ball, new Vector3(rb.position.x,rb.position.y, this.transform.position.z), new Quaternion(0, 0, 0, 0));
        }


    }
}
