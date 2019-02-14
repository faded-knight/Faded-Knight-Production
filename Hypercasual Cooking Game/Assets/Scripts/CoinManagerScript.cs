using UnityEngine;
using System.Collections;

public class CoinManagerScript : MonoBehaviour {

    public GameObject coinPrefab;

    private int collectedCoins = 0;

    private float coinsSpawnDelay = 20.0f;
    private float coinSpawnCooldown;

    void Start()
    {
        LoadData();

        coinSpawnCooldown = coinsSpawnDelay;
    }

	void Update () {

        if (coinSpawnCooldown > 0.0f)
            coinSpawnCooldown -= Time.deltaTime;
        else
        {
            coinSpawnCooldown = coinsSpawnDelay;
            SpawnCoin();
        }

	}

    void SpawnCoin()
    {
        float randX = Random.Range(-1.9f, 1.9f);
        float randY = Random.Range(-3.5f, 4.5f);

        GameObject newCoin = (GameObject)Instantiate(coinPrefab, new Vector3(randX, randY), transform.rotation);
        CoinScript script = newCoin.GetComponent<CoinScript>();
        script.manager = this;
    }

    public void IncreaseCollectedCoins()
    {
        collectedCoins++;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("collectedCoins", collectedCoins);
    }

    void LoadData()
    {
        collectedCoins = PlayerPrefs.GetInt("collectedCoins");
    }
}
