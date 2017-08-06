using UnityEngine;
using System.Collections;

public class ObstacileGenerator : MonoBehaviour {

    public float viewOffset;
    public GameObject[] ObstacileLocations;
    public GameObject[] ObstacilePrefabs;

    public void InstantiateObstaciles()
    {
        for( int t = 0; t < ObstacileLocations.Length; t++)
        {
            GameObject selected = ObstacilePrefabs[Random.Range(0, ObstacilePrefabs.Length)];
            Transform transform = ObstacileLocations[t].transform;
            Vector3 position = transform.position;
            position.z = position.z + viewOffset;
            GameObject obj = (GameObject)(Instantiate(selected, position, transform.rotation));
            obj.transform.parent = this.transform;
        }
    }
}
