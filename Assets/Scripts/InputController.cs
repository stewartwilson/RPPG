using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public GameObject leftFlipper;
    public GameObject rightFlipper;

    public float flipSpeed;
    public float flipRotation;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Flip R"))
        {
            SwingFlipper(rightFlipper, -flipRotation);
        }
        if(Input.GetButtonDown("Flip L"))
        {
            SwingFlipper(leftFlipper, flipRotation);
        }
	}

    private void SwingFlipper(GameObject _flipper, float _flipRotation)
    {
        _flipper.transform.Rotate(new Vector3(0, 0, _flipRotation), Space.Self);
    }
}
