using UnityEngine;
using System.Collections;

public class TrampolineScript : MonoBehaviour {

    //Private Vector References
    private Vector2 leftAnchor;
    private Vector2 rightAnchor;
    
    private Vector3 initialScale;
    
    //Public Float Variables
    [Range (0.1f, 0.5f)]
    public float minimumLength;

    [Range (1.0f, 4.0f)]
    public float maximumLength;

    [Range (1.0f, 200.0f)]
    public float strengthScalingValue;

    //Private Float Variables
    private float strength;


	// Use this for initialization
	void Start () {
        initialScale = transform.localScale;
	}

    public void InitializeDimensions(Vector2 anchor1, Vector2 anchor2)
    {
        if (transform != null)
        {
            transform.rotation = new Quaternion();
            transform.localScale = initialScale;
        }

        if (anchor1.x < anchor2.x)
        {
            leftAnchor = anchor1;
            rightAnchor = anchor2;
        }
        else
        {
            leftAnchor = anchor2;
            rightAnchor = anchor1;
        }

        float distance = Vector2.Distance(anchor1, anchor2);
        if (distance < minimumLength)
        {
            distance = minimumLength;
        } 
        else if (distance > maximumLength)
        {
            distance = maximumLength;
        }
        Vector2 differenceDirection = (anchor2 - anchor1).normalized;
        Vector2 center = anchor1 + differenceDirection * (distance / 2);

        transform.position = center;

        transform.localScale = new Vector3(distance, transform.localScale.y, 1);

        float angle = Mathf.Atan2(differenceDirection.y, differenceDirection.x); ;

        transform.Rotate(new Vector3(0, 0, 1), Mathf.Rad2Deg * angle);

        strength = strengthScalingValue / distance;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bouncer")
        {
            Debug.Log(other.contactCount);
            Vector2 collisionNormal = -1 * other.GetContact(0).normal.normalized;

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(collisionNormal * strength);

            //Deactivates Bool if max trampolines is not reached
            GameObject.FindGameObjectWithTag("GameController").GetComponent<InputHandler>().trampolinesFull = false;

            Destroy(gameObject);
        }
    }
}
