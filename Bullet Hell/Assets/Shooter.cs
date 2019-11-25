using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot(float direction, float vel, GameObject type, Vector3 position)
    {

        GameObject newbullet = Instantiate(type, new Vector3(position.x, position.y, this.transform.position.z), new Quaternion(0, 0, 0, 0));
        newbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(direction) * vel, Mathf.Sin(direction) * vel);

    }
}
