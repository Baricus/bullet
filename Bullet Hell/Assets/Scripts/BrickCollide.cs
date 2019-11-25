using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollide : Shooter
{
    int health = 3;

   
    void Start()
    {
    

      
    }

    // Update is called once per frame
    void Update()
    {
        
            GetComponent<SpriteRenderer>().color = new Color(0+(health*50), 0, 0);
        //Debug.Log("color: "+);
        

    }

    //called once per 1/60th of a second
    void FixedUpdate()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);//this refers to the calling component, so we grab the root object
        }
    }

    // Runs on the start of a collision with obj
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if this is a player's bullet
        if (collision.gameObject.CompareTag("Player Bullet"))
        {
            health -= 1;
            //do anything else we'd want (score etc.) in the future
        }
    }
}
