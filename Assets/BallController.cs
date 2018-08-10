using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public Vector2 collisionPoint;
    public bool forceAdded;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddForceToBall(Vector3 force)
    {
        if (!forceAdded)
        {
            forceAdded = true;
            GetComponent<Rigidbody2D>().AddForce(force);
        }
    }

    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Flipper"))
        {
            forceAdded = false;
        }
    }
}
