using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
    //Script References
    ScoreUIScript scoreScript;
    ExitScript exitScript;
    CoinManagerScript coinManager;

    //Object References
    public GameObject spawnObject;

    //Public Interactable Floats
    public float timeBetweenSpawns;
    public float gameTime;

    //Private Local Floats
    private float currentSpawnTimer;

    //Public Interactable Ints
    [Range(1, 10)]
    public int lives;

    //Private Local Ints
    [SerializeField]
    private int droppedBalls = 0;

    //References Objects, sets currentSpawnTimer, sets gameTime
	void Start () {
        currentSpawnTimer = timeBetweenSpawns;

        scoreScript = GameObject.FindGameObjectWithTag("UI").GetComponent<ScoreUIScript>();
        exitScript = GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitScript>();

        gameTime = 0.0f;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        coinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CoinManagerScript>();
	}
	
	void Update () {

        if (droppedBalls == lives)
        {
            Reset();
        }

        currentSpawnTimer += Time.deltaTime;

        gameTime += Time.deltaTime;

        if (currentSpawnTimer > timeBetweenSpawns)
        {
            SpawnObject();
        }
	}

    public void DropBall()
    {
        droppedBalls++;
        scoreScript.SetScoreDisplay();
    }

    public int GetLives()
    {
        return lives - droppedBalls;
    }

    public void Reset()
    {
        scoreScript.SaveHighScore();
        coinManager.SaveData();
        scoreScript.ResetPlayerScore();

        gameTime = 0.0f;
        currentSpawnTimer = timeBetweenSpawns;
        droppedBalls = 0;

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

    void SpawnObject()
    {
        GameObject obj = (GameObject)Instantiate(spawnObject, transform.position, transform.rotation);
        obj.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(Random.Range(-3.0f, 3.0f), 0);

        currentSpawnTimer = 0.0f;
    }
}
