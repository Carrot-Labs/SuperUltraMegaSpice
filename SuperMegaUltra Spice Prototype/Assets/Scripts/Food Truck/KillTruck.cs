using UnityEngine;
using System.Collections;

public class KillTruck : MonoBehaviour {
    private TruckScroll scrollScript;

    void Start()
    {
        scrollScript = GetComponent<TruckScroll>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            //kill the player
            PlayerManager player = other.GetComponent<PlayerManager>();
            player.dead = true;

            //set trucks speed to stop
            scrollScript.stop = true;
        }
    }
}
