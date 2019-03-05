using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour
{

    //---------------------
    //Script Created By
    // Callum Stirrup-Prazak
    //
    //---------------------

    //Struct or string references
    public GameObject nextObject;

    //Script References
    ScoreUIScript scoreScript;
    ExitScript exitScript;
    RecipesScript recipeScript;

    //Private Game Object References
    private GameObject recipeUI;

    //Public Game Object References
    public GameObject[] ingredientsPrefab;

    [Header("Changeable Game Values")]
    //Public Interactable Floats
    public float timeBetweenSpawns;

    public float axisX;
    public float axisY;
    public float axisZ;

    //Private Local Floats
    private float currentSpawnTimer;
    [SerializeField]
    private float maxSpawnedIngredients = 5;
    private float gameTime;

    //Public Interactable Ints
    [Range(1, 10)]
    public int lives;

    //Private Interactable Ints
    private int droppedBalls = 0;
    private int RandInt;

    //Decides the first object to spawn in the game
    private void Awake()
    {
        recipeUI = GameObject.Find("RecipeUI");

        DecideObject();
    }

    //References Objects, sets currentSpawnTimer, sets gameTime
    void Start()
    {
        currentSpawnTimer = timeBetweenSpawns;

        scoreScript = GameObject.FindGameObjectWithTag("UI").GetComponent<ScoreUIScript>();
        exitScript = GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitScript>();
        recipeScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<RecipesScript>();

        exitScript.currentSpawnedIngredients = 0;

        gameTime = 0.0f;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

    }

    void Update()
    {

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

    //Decides next ingredient to Spawn
    void DecideObject()
    {
        RandInt = Random.Range(0, ingredientsPrefab.Length);
        GameObject obj = ingredientsPrefab[RandInt];
        nextObject = ingredientsPrefab[RandInt];
        NextIngredient();
    }

    void NextIngredient()
    {
        //References the Child Objects of the RecipeUI Parent
        Transform[] t = recipeUI.GetComponentsInChildren<Transform>();

        Transform theParent = t[0];
        Transform firstChild = t[1];

        t[1].GetComponent<Image>().sprite = ingredientsPrefab[RandInt].GetComponentInChildren<SpriteRenderer>().sprite;
    }

    //Spawns Ingredient defined in DecideObject() and adds to currentSpawnedIngredients, resets currentSpawnTimer
    void SpawnObject()
    {

        GameObject obj = Instantiate(ingredientsPrefab[RandInt], transform.position, transform.rotation * Quaternion.Euler(axisX, axisY, axisZ));

        currentSpawnTimer = 0.0f;
        exitScript.currentSpawnedIngredients++;

        DecideObject();

        Debug.Log(exitScript.currentSpawnedIngredients);

    }
}
