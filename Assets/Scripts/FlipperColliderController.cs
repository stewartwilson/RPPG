using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperColliderController : MonoBehaviour {

    public Vector2 collisionPoint;

    public bool hasCollided;
    public bool isMoving;

    private FlipperController controller;

    private void Start()
    {
        controller = GetComponentInParent<FlipperController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasCollided = true;
        collisionPoint = collision.contacts[0].point;
        if(isMoving && collision.gameObject.tag.Equals("Ball"))
        {
            collision.gameObject.GetComponent<BallController>().AddForceToBall(controller.getForceApplied(collisionPoint));
            isMoving = false;
        }
    }
}
