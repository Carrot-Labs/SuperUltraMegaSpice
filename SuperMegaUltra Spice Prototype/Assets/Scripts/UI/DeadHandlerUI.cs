using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeadHandlerUI : MonoBehaviour {

    public GameObject[] OtherUICanvas;
    public GameObject DeadScreenCanvas;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            //disable other UIs
            foreach(GameObject obj in OtherUICanvas)
            {
                obj.SetActive(false);
            }

            //enable Dead UI
            DeadScreenCanvas.SetActive(true);

            //set block Text to the blocks cleared
            Transform TextObj = DeadScreenCanvas.transform.FindChild("Text");
            TextObj.gameObject.GetComponent<Text>().text = "Blocks Ran: " + other.GetComponent<PlayerManager>().blocksCleared;
        }
    }
}
