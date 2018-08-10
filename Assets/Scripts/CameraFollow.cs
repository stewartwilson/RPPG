using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float minY;
    public float maxY;

    public GameObject ballToFollow;

	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, ballToFollow.transform.position.y, transform.position.z);
        if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY,transform.position.z);
        }
        if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }
    }
}
