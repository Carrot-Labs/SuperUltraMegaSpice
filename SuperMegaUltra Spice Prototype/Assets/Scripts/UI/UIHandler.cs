using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHandler : MonoBehaviour
{
    public GameObject UICanavasTarget;
    public bool UpdateScreen;

    void Start()
    {
        if (UpdateScreen)
        {
            //search for the UpdateUI canvas
            UICanavasTarget = GameObject.FindGameObjectWithTag("UpdateUICanvas");
        }
    }

    //On enter Active the target canvas
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            //set the text fields active
            foreach(Transform child in UICanavasTarget.transform)
            {
                child.gameObject.SetActive(true);
            }

            //if it is the update screen then display the values as well
            if (UpdateScreen)
            {
                PlayerManager player = other.GetComponent<PlayerManager>();
                int blockCount = player.blocksCleared;
                UICanavasTarget.GetComponentInChildren<Text>().text = "Blocks Ran: " + (blockCount + 1);
            }
        }
    }

    //On exit disable the the target canvas
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            foreach(Transform child in UICanavasTarget.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
