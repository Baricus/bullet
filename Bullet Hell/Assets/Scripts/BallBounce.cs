using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    //rigidbody
    private Rigidbody2D rb;
    //sprite
    private SpriteRenderer sprite;

    //edges
    private Vector2 screenEdges;

    //extent of sprite
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        //set up parameters
        rb = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();

        //initialization

        //gets edges
        screenEdges = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //gets width and height of circle
        width = sprite.bounds.extents.x / 2;
        height = sprite.bounds.extents.y / 2;
    }

    //called at a fixed time interval
    void FixedUpdate()
    {

        //checks for screen edge and swaps 


        if ((transform.position.x - width + screenEdges.x) <= 0)//left edge
        {
            //swap x velocity
            if (rb.velocity.x < 0)
            {
                rb.velocity = new Vector2(-1 * rb.velocity.x, rb.velocity.y);
            }
        }

        if ((transform.position.x + width - screenEdges.x) >= 0)//right edge
        {
            //swap x velocity
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(-1 * rb.velocity.x, rb.velocity.y);
            }
        }

        if ((transform.position.y + height - screenEdges.y) >= 0)//top edge
        {
            //swap y velocity
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -1 * rb.velocity.y);
            }
        }


        //deletes on bottom edge
        if ((transform.position.y + height + screenEdges.y) <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //updates edges and bounds in case of camera shift

        //gets edges
        screenEdges = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //gets width and height of circle
        width = sprite.bounds.extents.x;
        height = sprite.bounds.extents.y;
    }
}
