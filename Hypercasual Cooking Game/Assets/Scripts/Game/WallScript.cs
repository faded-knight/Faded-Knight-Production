using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    //    // attempted fix for wall sliding bug
    void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.tag == "Bouncer")
        //{
        //    Rigidbody2D bouncerBody = other.gameObject.GetComponent<Rigidbody2D>();

        //    Vector2 otherVelocityDirection = bouncerBody.velocity.normalized;

        //    float dotWithDown = Vector2.Dot(otherVelocityDirection, Vector2.down);

        //    if (dotWithDown > 0.9f || dotWithDown < -0.9f)
        //    {
        //        bouncerBody.AddForce(new Vector2(1.0f, 0.0f));
        //    }
        //}

    }
}
