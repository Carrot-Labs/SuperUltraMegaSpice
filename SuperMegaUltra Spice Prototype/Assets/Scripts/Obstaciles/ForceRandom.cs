using UnityEngine;
using System.Collections;

public class ForceRandom : MonoBehaviour {
    public float minYForce;
    public float maxYForce;
    public float minXForce;
    public float maxXForce;

    private Rigidbody2D rd;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Player"))
        {
            //apply force with some +y and some +x value to make it go flying
            rd.AddForce(new Vector2(Random.Range(minXForce, maxXForce), Random.Range(minYForce, maxYForce)));
        }
    }
}
