using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
        float horiz = Input.GetAxis("Horizontal");//will this allow me to get shoot input?
        float vert = Input.GetAxis("Vertical");

        Shoot();

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
           
            ActualMousePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
           GameObject newball= Instantiate(ball, new Vector3(rb.position.x,rb.position.y, this.transform.position.z), new Quaternion(0, 0, 0, 0));


            //float fireangle = Vector2.Angle(new Vector2(ActualMousePosition.x, ActualMousePosition.y), rb.position);
            float fireangle = Mathf.Atan2((ActualMousePosition.y-rb.position.y),(ActualMousePosition.x-rb.position.x));


            //Debug.Log("Firing angle " + fireangle*Mathf.Rad2Deg);
           //Debug.Log("coordinate of paddle" + rb.position);
           
            
            
            newball.GetComponent<Rigidbody2D>().velocity=new Vector2(Mathf.Cos(fireangle)*firevelocity,Mathf.Sin(fireangle)*firevelocity);
            cooldowntime = 60;
        }


    }
}
