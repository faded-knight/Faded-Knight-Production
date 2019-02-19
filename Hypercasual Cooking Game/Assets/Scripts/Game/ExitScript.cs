using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {
    //Script References
    ScoreUIScript scoreDisplay;
    SpawnerScript ingredientScript;

    //Public Float Variables
    public float activeTime;
    public float loopTime;
    [HideInInspector]
    public float currentSpawnedIngredients;

    //Private Float Variables
    private float scaleY = 0.0f;
    private float timer = 0.0f;
    private float lerpTime = 1.0f;



	// Use this for initialization
	void Start () {
        scoreDisplay = GameObject.FindGameObjectWithTag("UI").GetComponent<ScoreUIScript>();
        InitializePosition();
	}

	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            InitializePosition();
        }
        else if (timer < activeTime && timer > activeTime - lerpTime)
        {
            scaleY = easeOut(activeTime - timer, 0, 1, 1);
        }
        else if (timer < lerpTime)
        {
            scaleY = easeOut(timer, 0, 1, 1);
        }
        else if (timer > activeTime)
        {
            scaleY = 0.0f;
        }
        else
        {
            scaleY = 1.0f;
        }

        UpdateDimensions();
	}

    void UpdateDimensions()
    {
        transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
    }

    // x position: +- 2.63f
    // y position: between -2.5f and 4.0f
    // don't change z position
    // scale of zero
    void InitializePosition()
    {
        timer = loopTime;

        float xPosition = (Random.Range(0, 2) == 0 ? 2.7f : -2.7f);
        float yPosition = Random.Range(-2.5f, 4.0f);
        float zPosition = transform.position.z;

        transform.position = new Vector3(xPosition, yPosition, zPosition);

        scaleY = 0.0f;

        UpdateDimensions();
    }

    public void Reset()
    {
        InitializePosition();
        timer = loopTime;
    }

    void SaveSheep(GameObject sheep)
    {
        Destroy(sheep);
        scoreDisplay.IncrementPlayerScore();
        currentSpawnedIngredients--;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bouncer")
        {
            SaveSheep(other.gameObject);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="t">elapsed time</param>
    /// <param name="b">start value</param>
    /// <param name="c">end value</param>
    /// <param name="d">total</param>
    /// <returns></returns>
    float easeIn(float t, float b, float c, float d)
    {
        float s = 1.70158f;
        float postFix = t /= d;
        return c * (postFix) * t * ((s + 1) * t - s) + b;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="t">elapsed time</param>
    /// <param name="b">start value</param>
    /// <param name="c">end value</param>
    /// <param name="d">total</param>
    /// <returns></returns>
    float easeOut(float t,float b , float c, float d) 
    {	
	    float s = 1.70158f;
	    return c*((t=t/d-1)*t*((s+1)*t + s) + 1) + b;
    }

}
