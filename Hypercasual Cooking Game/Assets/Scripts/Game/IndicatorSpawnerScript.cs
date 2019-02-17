using UnityEngine;
using System.Collections;

public class IndicatorSpawnerScript : MonoBehaviour {

    public GameObject indicatorPrefab;

    void OnTriggerEnter2D(Collider2D bouncer)
    {
        if (bouncer.gameObject.tag == "Bouncer")
        {
            GameObject indicator = (GameObject)Instantiate(indicatorPrefab);
            indicator.GetComponent<IndicatorScript>().SetParentBall(bouncer.gameObject);
        }
    }

}
