using UnityEngine;
using System.Collections;

public class SheepScript : MonoBehaviour {

    public bool falling = true;

	void Start () {
	
	}

	void Update () {
	
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
