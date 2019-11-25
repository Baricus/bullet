using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    //path to follow
    public GameObject path;

    //delay on starting path
    public float delay;

    //distance to swap nodes
    public float swapDistance;


    //list of nodes to follow
    private List<GameObject> waypoints;

    //timers
    private float timeAlive = 0;
    private float segmentTime = 0;
    private int nodeCount = 0;

    //vector to hold position for each segment
    private Vector2 tempPos;

    //rigidbody
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //intialize
        waypoints = new List<GameObject>();

        //for every child object in the path's transform
        foreach(Transform child in path.transform)
        {
            //add it's parent gameobject to the list
            waypoints.Add(child.gameObject);
        }

        //grabs rigidbody
        rb = GetComponent<Rigidbody2D>();
    }


    // Called every physics tick
    void FixedUpdate()
    {
        //if this is the first frame
        if (timeAlive == 0)
        {
            transform.position = path.transform.position;

            //set's tempPos to current position;
            tempPos = transform.position;
        }

        //if we're alive longer than the delay
        if (timeAlive >= delay)
        {
            //if we're not at the node
            if (transform.position != waypoints[nodeCount].transform.position)
            {
                //pro of lerping!
                //first get lerp time
                float lerpTime = segmentTime / waypoints[nodeCount].GetComponent<NodeData>().timeToArrive;
                rb.position = Vector2.Lerp(
                    tempPos,
                    waypoints[nodeCount].transform.position,
                    lerpTime
                    );
            }
            else//we need to start moving to new node
            {
                segmentTime = 0;
                nodeCount++;

                //update tempPos
                tempPos = transform.position;
            }


            //add to timeMoving
            segmentTime += Time.fixedDeltaTime;
        }

        //add time.delta time
        timeAlive += Time.fixedDeltaTime;

        
        //if we are out of waypoints, delete this component
        if (waypoints.Count == nodeCount)
        {
            Destroy(this);
        }
    }
}



//old velF
/*

//get velocity vector
Vector2 vel = rb.velocity;


Vector2.SmoothDamp(
    path.transform.position,
    waypoints[0].transform.position,
    ref vel,
    waypoints[0].GetComponent<NodeData>().timeToArrive
    );
*/
