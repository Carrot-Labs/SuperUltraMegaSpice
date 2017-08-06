using UnityEngine;
using System.Collections;

public class BlockGenerator : MonoBehaviour {

    public GameObject[] chunckBackgrounds;
    public GameObject Block;
    public Vector3 startBlockPosition;
    public static int blockCount = 0;

    public int initialSize;
    public int offset;
    public GameObject OpenLotPrefab;

    public float speedIncrementAmount;
    public float MaxSpeed;

    private Vector3 chunckPosition;
    private static Vector3 WorldSpaceChunckPointer = new Vector3(0f,0f,0f);
    private GameObject Truck;

    void Start()
    {
        Truck = GameObject.FindGameObjectWithTag("Food Truck");
    }

    //when the user enters the trigger to generate next block
    void OnTriggerEnter2D(Collider2D other)
    {
        //if collider is player
        if (other.tag.Equals("Player"))
        {
            //update blocks player finished and the speed increment
            //also update the speed of the truck
            other.GetComponent<PlayerManager>().blocksCleared = blockCount;
            float speed = other.GetComponent<PlayerScroller>().speed;
            float tspeed = Truck.GetComponent<TruckScroll>().speed;
            if(speed < MaxSpeed)
            {
                speed = speed + speedIncrementAmount;
                tspeed = tspeed + speedIncrementAmount;
            }
            other.GetComponent<PlayerScroller>().speed = speed;
            Truck.GetComponent<TruckScroll>().speed = tspeed;


            GameObject block = (GameObject)(Instantiate(Block, startBlockPosition, Quaternion.identity));

            //initalize block offset
            chunckPosition = WorldSpaceChunckPointer + startBlockPosition;

            //calculate the block and display it
            StartCoroutine(GenerateBlock(block));
        }
    }

    //Coroutine to loop and calculate block
    IEnumerator GenerateBlock(GameObject block)
    {
        for (int i = 0; i < blockCount + initialSize; i++)
        {       
            //get a chunck and instantiate it setting its parent to a block
            GameObject chunck = chunckBackgrounds[Random.Range(0, chunckBackgrounds.Length)];
            GameObject chunckObj = (GameObject)(Instantiate(chunck, chunckPosition, Quaternion.identity));
            chunckObj.transform.parent = block.transform;

            //generate all platforms
            ChunckGenerator chunkScript = chunckObj.GetComponent<ChunckGenerator>();
            chunkScript.InstantiatePlatformSpots();

            //generate all Obsticles slowable or not
            ObstacileGenerator ObsScript = chunckObj.GetComponent<ObstacileGenerator>();
            ObsScript.InstantiateObstaciles();

            //increment chunck offset
            chunckPosition.x += offset;

            yield return null;
        }

        //increment block count
        blockCount++;

        //add open so next generation
        Instantiate(OpenLotPrefab, chunckPosition, Quaternion.identity);
        WorldSpaceChunckPointer.x = chunckPosition.x;
    }
}
