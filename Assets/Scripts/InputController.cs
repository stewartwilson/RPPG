using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public GameObject leftFlipper;
    public GameObject rightFlipper;
    public float flipDelay;
    public float unflipDelay;
    public float flipSpeed;
    public float flipRotation;
    public float flipDiff;


    private bool leftFlipping;
    private bool leftUnFlipping;
    private bool rightFlipping;
    private bool rightUnFlipping;
    private float leftStartRotation;
    private float rightStartRotation;
    private float leftRotationTarget;
    private float rightRotationTarget;

    // Use this for initialization
    void Start () {
        leftFlipping = false;
        rightFlipping = false;

        leftStartRotation = leftFlipper.transform.rotation.eulerAngles.z;
        rightStartRotation = rightFlipper.transform.rotation.eulerAngles.z;
        leftRotationTarget = leftStartRotation;
        rightRotationTarget = rightStartRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rightFlipping && Input.GetButtonDown("Flip R"))
        {
            StartCoroutine(FlipRight());
        }
        if (!leftFlipping && Input.GetButtonDown("Flip L"))
        {
            StartCoroutine(FlipLeft());
        }

        if(leftFlipping && Input.GetButtonUp("Flip L"))
        {
            StartCoroutine(UnFlipLeft());
        }
        if (leftFlipping && Input.GetButtonUp("Flip R"))
        {
            StartCoroutine(UnFlipRight());
        }

        if (rightFlipping)
        {

            rightFlipper.transform.rotation = Quaternion.RotateTowards(rightFlipper.transform.rotation, Quaternion.Euler(0, 0, rightRotationTarget), flipSpeed);
            /*if (Mathf.Abs(rightRotationTarget - rightFlipper.transform.rotation.eulerAngles.z) % 360 < flipDiff)
            {
                rightRotationTarget = rightStartRotation;
            }*/
        }
        if (leftFlipping)
        {
            leftFlipper.transform.rotation = Quaternion.RotateTowards(leftFlipper.transform.rotation, Quaternion.Euler(0, 0, leftRotationTarget), flipSpeed);
            /*if (Mathf.Abs(leftRotationTarget - leftFlipper.transform.rotation.eulerAngles.z) % 360 < flipDiff)
            {
                leftRotationTarget = leftStartRotation;
            }*/
        }
    }

    IEnumerator FlipLeft()
    {
        leftFlipping = true;
        leftRotationTarget = leftStartRotation + flipRotation;
        yield return new WaitForSeconds(flipDelay);
    }

    IEnumerator UnFlipLeft()
    {
        leftRotationTarget = leftStartRotation;
        yield return new WaitForSeconds(unflipDelay);
        leftFlipping = false;
    }

    IEnumerator FlipRight()
    {
        rightFlipping = true;
        rightRotationTarget = rightStartRotation - flipRotation;
        yield return new WaitForSeconds(flipDelay);
    }

    IEnumerator UnFlipRight()
    {
        rightRotationTarget = rightStartRotation;
        yield return new WaitForSeconds(unflipDelay);
        rightFlipping = false;
    }
}
