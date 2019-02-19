using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    //Script References
    ScoreUIScript scoreScript;
    ExitScript exitScript;

    //Object References
    [Header("Insert Ingredients Here")]
    public GameObject[] ingredientsPrefab;

    [Header("Changeable Game Values")]
    //Public Interactable Floats
    public float timeBetweenSpawns;
    [HideInInspector]
    public float gameTime;

    //Private Local Floats
    private float currentSpawnTimer;
    [SerializeField]
    private float maxSpawnedIngredients = 5;

    //Public Interactable Ints
    [Range(1, 10)]
    public int lives;

    //Private Local Ints
    private int droppedBalls = 0;

    //References Objects, sets currentSpawnTimer, sets gameTime
	void Start () {
        currentSpawnTimer = timeBetweenSpawns;

        scoreScript = GameObject.FindGameObjectWithTag("UI").GetComponent<ScoreUIScript>();
        exitScript = GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitScript>();

        exitScript.currentSpawnedIngredients = 0;

        gameTime = 0.0f;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

	}
	
	void Update () {

        if (droppedBalls == lives)
        {
            Reset();
        }

        currentSpawnTimer += Time.deltaTime;

        gameTime += Time.deltaTime;

        if (currentSpawnTimer > timeBetweenSpawns && exitScript.currentSpawnedIngredients < maxSpawnedIngredients)
        {
            SpawnObject();
        }
	}

    //Removes 1 from currentSpawnedIngredients and Removes a life
    public void DropBall()
    {
        droppedBalls++;
        scoreScript.SetScoreDisplay();
        exitScript.currentSpawnedIngredients--;
    }


    public int GetLives()
    {
        return lives - droppedBalls;
    }

    //Resets all values if player loses game
    public void Reset()
    {
        scoreScript.SaveHighScore();
        scoreScript.ResetPlayerScore();

        gameTime = 0.0f;
        currentSpawnTimer = timeBetweenSpawns;
        droppedBalls = 0;
        exitScript.currentSpawnedIngredients = 0;

        exitScript.Reset();

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Bouncer"))
        {
            Destroy(obj);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Trampoline"))
        {
            Destroy(obj);
        }
    }

    //Spawns A random ingredient and adds to currentSpawnedIngredients, resets currentSpawnTimer
    void SpawnObject()
    {
        int RandInt = Random.Range(0, ingredientsPrefab.Length);
            GameObject obj = (GameObject)Instantiate(ingredientsPrefab[RandInt], transform.position, transform.rotation);

        currentSpawnTimer = 0.0f;
        exitScript.currentSpawnedIngredients++;

        Debug.Log(exitScript.currentSpawnedIngredients);
    }
}
