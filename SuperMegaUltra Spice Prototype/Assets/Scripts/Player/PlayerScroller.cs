using UnityEngine;
using System.Collections;

public class PlayerScroller : MonoBehaviour {

    public bool isDead = false;
    public bool collisionWithObject = false;
    public float speed;
    private Rigidbody2D rd;

	// Use this for initialization
	void Start () {
        rd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!isDead)
        {
            //make the player move constant speed in xdirection
            Vector2 newVelocity = new Vector2(speed, rd.velocity.y);
            rd.velocity = newVelocity;
        }
        else
        {
            //make the player stop moving forward
            rd.velocity = Vector3.zero;
        }
	}

    void Update()
    {
        //detect collision with an object on x axis by dtermineng the change of location per frame
    }
}
