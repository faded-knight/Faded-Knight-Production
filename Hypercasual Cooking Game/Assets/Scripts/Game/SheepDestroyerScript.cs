using UnityEngine;
using System.Collections;

public class SheepDestroyerScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bouncer")
        {
            Destroy(other.gameObject);
        }
    }
}
