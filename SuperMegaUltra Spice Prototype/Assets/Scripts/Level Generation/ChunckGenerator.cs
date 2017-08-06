using UnityEngine;
using System.Collections;

[System.Serializable]
public class RandomRangeX
{
    public float minX;
    public float maxX;
}

public class ChunckGenerator : MonoBehaviour {

    public float viewOffset;
    public RandomRangeX xRange;

    public GameObject[] PlatformSpotsSet;
    public GameObject[] AvailablePlatforms;

    public void InstantiatePlatformSpots()
    {
        for(int t = 0; t < PlatformSpotsSet.Length; t++)
        {
            GameObject obj = AvailablePlatforms[Random.Range(0, AvailablePlatforms.Length)];
            Vector3 position = PlatformSpotsSet[t].transform.position;
            position.z = position.z + viewOffset;
            position.x = position.x + Random.Range(xRange.minX, xRange.maxX) * Mathf.Pow(-1f,Random.Range(1,2));
            obj = (GameObject)(Instantiate(obj, position, PlatformSpotsSet[t].transform.rotation));
            obj.transform.parent = gameObject.transform;
        }
    }
}
