using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float minY, maxY;
}

public class CameraTrack : MonoBehaviour {

    public GameObject target;
    public float xOffset = 0;
    public float yOffset = 0;
    public Boundary yBound;

    void LateUpdate()
    {
        //set position
        Vector3 position = new Vector3(target.transform.position.x + xOffset,
                                       target.transform.position.y + yOffset,
                                       transform.position.z);

        //bound check the y axis
        if (yBound.minY > position.y)
            position.y = yBound.minY;

        //assign final position
        transform.position = position;
    }
}
