using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    //public brick
    public GameObject brick;

    //number to generate
    public int rows;
    public int columns;

    //stuff to get screen edges
    private Vector2 screenEdges;

    //sprite
    private SpriteRenderer sprite;
    //extent of sprite
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Awake is used when object is "turned on"
    void Awake()
    {
        //get's sprite
        sprite = brick.GetComponent<SpriteRenderer>();

        //gets edges
        screenEdges = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //gets width and height of brick
        width = sprite.bounds.extents.x;
        height = sprite.bounds.extents.y;

        //computes spacing
        Vector2 spacing = new Vector2(screenEdges.x / (columns * (width)) * 2, (screenEdges.y / 3) / (rows * (2 * height)));

        //generate bricks
        for (int i = 0; i < rows; i++)
        {
            //y coord
            float vPos = screenEdges.y - i * spacing.y - height;

            for (int j = 0; j < columns; j++)
            {
                //x coord
                float hPos = screenEdges.x - j * spacing.x - width;

                //spawn brick
                Instantiate<GameObject>(brick, new Vector3(hPos, vPos, this.transform.position.z), new Quaternion(0, 0, 0, 0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
