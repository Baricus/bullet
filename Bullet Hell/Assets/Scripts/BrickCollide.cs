using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Runs on the start of a collision with obj
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if this is a player's bullet
        if (collision.gameObject.CompareTag("Player Bullet"))
        {
            //do anything else we'd want (score etc.) in the future

            Destroy(this.gameObject);//this refers to the calling component, so we grab the root object
        }
    }
}
