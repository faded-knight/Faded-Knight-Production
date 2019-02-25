using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbScript : MonoBehaviour {

    //Public Bools
    public bool falling = true;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (!falling)
        {
            //move sheep down slowly
            transform.position -= new Vector3(0, 0.3f * Time.deltaTime, 0);
        }
    }

    public void GetAbsorbed()
    {
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<TrailRenderer>());
        falling = false;
        gameObject.layer = 10;

    }
}
