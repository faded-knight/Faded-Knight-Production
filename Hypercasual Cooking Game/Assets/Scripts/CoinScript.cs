using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

    public CoinManagerScript manager;

    private float coinLifeTime = 10.0f;

	void Update () {

        coinLifeTime -= Time.deltaTime;

        if (coinLifeTime <= 0.0f)
        {
            Destroy(gameObject);
        }

        transform.Rotate(transform.up, 4 * Time.deltaTime);

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            AddCoin();
            Destroy(gameObject);
        }
    }

    void AddCoin()
    {
        manager.IncreaseCollectedCoins();
    }
}
