using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public GameObject leftFlipper;
    public GameObject rightFlipper;
    public GameObject ball;
    public float flipDelay;
    public float unflipDelay;
    public float flipSpeed;
    public float flipRotation;
    public float flipDiff;
    public float flipperForce;


    private bool leftFlipping;
    private bool leftUnFlipping;
    private bool rightFlipping;
    private bool rightUnFlipping;
    private float leftStartRotation;
    private float rightStartRotation;
    private float leftRotationTarget;
    private float rightRotationTarget;
    private FlipperColliderController leftFlipperCollider;
    private FlipperColliderController rightFlipperCollider;

    // Use this for initialization
    void Start () {
        leftFlipping = false;
        rightFlipping = false;

        leftStartRotation = leftFlipper.transform.rotation.eulerAngles.z;
        rightStartRotation = rightFlipper.transform.rotation.eulerAngles.z;
        leftRotationTarget = leftStartRotation;
        rightRotationTarget = rightStartRotation;
        leftFlipperCollider = leftFlipper.GetComponentInChildren<FlipperColliderController>();
        rightFlipperCollider = rightFlipper.GetComponentInChildren<FlipperColliderController>();
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
        if (rightFlipping && Input.GetButtonUp("Flip R"))
        {
            StartCoroutine(UnFlipRight());
        }

        if (rightFlipping)
        {
            /*if(rightFlipperCollider.hasCollided)
            {
                
                Vector3 forceApplied = rightFlipper.GetComponent<FlipperController>().lineNormal * flipperForce;
                ball.GetComponent<BallController>().AddForceToBall(forceApplied);
            }*/
            rightFlipper.transform.rotation = Quaternion.RotateTowards(rightFlipper.transform.rotation, Quaternion.Euler(0, 0, rightRotationTarget), flipSpeed);
            /*if (Mathf.Abs(rightRotationTarget - rightFlipper.transform.rotation.eulerAngles.z) % 360 < flipDiff)
            {
                rightRotationTarget = rightStartRotation;
            }*/
        }
        if (leftFlipping)
        {
            /*if (leftFlipperCollider.hasCollided)
            {
                Vector3 forceApplied = rightFlipper.GetComponent<FlipperController>().lineNormal * flipperForce;
                ball.GetComponent<BallController>().AddForceToBall(forceApplied);
            }*/
            leftFlipper.transform.rotation = Quaternion.RotateTowards(leftFlipper.transform.rotation, Quaternion.Euler(0, 0, leftRotationTarget), flipSpeed);
            /*if (Mathf.Abs(leftRotationTarget - leftFlipper.transform.rotation.eulerAngles.z) % 360 < flipDiff)
            {
                leftRotationTarget = leftStartRotation;
            }*/
        }

        if((Mathf.Abs(leftStartRotation - leftFlipper.transform.rotation.eulerAngles.z) % 360 < flipDiff))
        {
            leftFlipping = false;
        }
        if ((Mathf.Abs(rightStartRotation - rightFlipper.transform.rotation.eulerAngles.z) % 360 < flipDiff))
        {
            rightFlipping = false;
        }
    }

    IEnumerator FlipLeft()
    {
        leftFlipping = true;
        leftRotationTarget = leftStartRotation + flipRotation;
        leftFlipper.GetComponentInChildren<FlipperColliderController>().isMoving = true;
        yield return new WaitForSeconds(flipDelay);
    }

    IEnumerator UnFlipLeft()
    {
        leftRotationTarget = leftStartRotation;
        leftFlipper.GetComponentInChildren<FlipperColliderController>().isMoving = false;
        yield return new WaitForSeconds(unflipDelay);
    }

    IEnumerator FlipRight()
    {
        rightFlipping = true;
        rightRotationTarget = rightStartRotation - flipRotation;
        rightFlipper.GetComponentInChildren<FlipperColliderController>().isMoving = true;
        yield return new WaitForSeconds(flipDelay);
    }

    IEnumerator UnFlipRight()
    {
        rightRotationTarget = rightStartRotation;
        rightFlipper.GetComponentInChildren<FlipperColliderController>().isMoving = false;
        yield return new WaitForSeconds(unflipDelay);
    }

    IEnumerator AddForceToBall(Vector3 forceApplied)
    {
        ball.GetComponent<Rigidbody2D>().AddForce(forceApplied);
        yield return new WaitForSeconds(.2f);
    }
}
