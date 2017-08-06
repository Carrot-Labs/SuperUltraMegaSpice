using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

    public float offset;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            //determine whether stay trigger or change to collider
            if(other.transform.position.y > this.transform.position.y + offset)
            {
                //change to collider
                this.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
    }
}
