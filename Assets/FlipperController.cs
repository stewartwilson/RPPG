using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour {
    public Vector3 lineNormal;
    public float magnitude;
    public GameObject pointL;
    public GameObject pointR;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newVec = (pointL.transform.position - pointR.transform.position);
        lineNormal = Vector3.Cross(newVec, Vector3.forward);
    }

    public Vector3 getForceApplied(Vector3 contactPoint)
    {
        return lineNormal * magnitude;
    }
}
