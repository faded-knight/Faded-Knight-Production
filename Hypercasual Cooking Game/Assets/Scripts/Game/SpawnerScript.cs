using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    public float timeBetweenSpawns;
    private float currentSpawnTimer;
    public GameObject spawnObject;

    ScoreUIScript scoreScript;

    ExitScript exitScript;

    public float gameTime;

    private int DroppedBalls = 0;

    [Range (1, 10)]
    public int lives;

    CoinManagerScript coinManager;

	void Start () {
        currentSpawnTimer = timeBetweenSpawns;

        scoreScript = GameObject.FindGameObjectWithTag("UI").GetComponent<ScoreUIScript>();
        exitScript = GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitScript>();

        gameTime = 0.0f;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManagerScript>();
	}
	
	void Update () {

        if (DroppedBalls == lives)
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
        DroppedBalls++;
        scoreScript.SetScoreDisplay();
    }

    public int GetLives()
    {
        return lives - DroppedBalls;
    }

    public void Reset()
    {
        scoreScript.SaveHighScore();
        coinManager.SaveData();
        scoreScript.ResetPlayerScore();

        gameTime = 0.0f;
        currentSpawnTimer = timeBetweenSpawns;
        DroppedBalls = 0;

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
