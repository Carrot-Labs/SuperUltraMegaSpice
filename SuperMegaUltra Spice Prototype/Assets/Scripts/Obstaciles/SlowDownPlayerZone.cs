using UnityEngine;
using System.Collections;

public class SlowDownPlayerZone : MonoBehaviour {

    public float slowdownPercent;

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Player"))
        {
            //player only has fraction of velocity
            Rigidbody2D player_rd = other.collider.GetComponent<Rigidbody2D>();
            Vector2 velocity = player_rd.velocity;
            Vector2 new_velocity = velocity - velocity * slowdownPercent / 100;
            player_rd.velocity = new_velocity;
        }
    }
}
