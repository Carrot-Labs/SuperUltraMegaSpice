using UnityEngine;
using System.Collections;

public class TruckScroll : MonoBehaviour {

    public float speed;
    public bool stop = false;
    private Rigidbody2D rd;

    // Use this for initialization
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            //make the player move constant speed in xdirection
            Vector2 newVelocity = new Vector2(speed, rd.velocity.y);
            rd.velocity = newVelocity;
        }
        else
        {
            rd.velocity = Vector3.zero;
        }
    }
}
