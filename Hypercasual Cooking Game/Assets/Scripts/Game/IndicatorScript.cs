using UnityEngine;
using System.Collections;

public class IndicatorScript : MonoBehaviour {

    GameObject parentBouncer;

    float topOfScreen;

	// Use this for initialization
	void Start () {
        topOfScreen = 5.0f;
	}

    public void SetParentBall(GameObject inputBouncer)
    {
        parentBouncer = inputBouncer;
    }
	
	// Update is called once per frame
	void Update () {

        if (parentBouncer != null)
        {
            transform.position = new Vector2(parentBouncer.transform.position.x, topOfScreen);

            float scalingFactor = 1 - ((parentBouncer.transform.position.y - topOfScreen) / topOfScreen) / 1.5f;

            Debug.Log("scaling factor: " + scalingFactor);

            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f) * scalingFactor;

            if (parentBouncer.transform.position.y < topOfScreen)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
