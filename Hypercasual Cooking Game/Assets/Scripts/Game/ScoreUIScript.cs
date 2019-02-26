using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUIScript : MonoBehaviour {

    //---------------------
    //Script Edits By
    // Callum Stirrup-Prazak
    //
    //---------------------

    //Script References
    SpawnerScript gameController;
    
    //Private Object References
    private Text HighScore;
    private Text CurrentScore;
    private Text Lives;

    //Constant References
    string highScoreKey = "HighScore";
    
    //Private Int Variables
    private int highScoreValue;
    [SerializeField]
    private int playerCurrentScore;

    // Use this for initialization
    void Start()
    {
        HighScore = gameObject.GetComponentsInChildren<Text>()[0];
        CurrentScore = gameObject.GetComponentsInChildren<Text>()[1];
        Lives = gameObject.GetComponentsInChildren<Text>()[2];

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnerScript>();

        highScoreValue = PlayerPrefs.GetInt(highScoreKey, 0);

        SetScoreDisplay();
    }

    public void SetScoreDisplay()
    {
        if (playerCurrentScore > highScoreValue)
        {
            highScoreValue = playerCurrentScore;
        }

        Lives.text = "Lives: " + gameController.GetLives();

        HighScore.text = "Best: " + highScoreValue.ToString();

        CurrentScore.text = "Score: " + playerCurrentScore;
    }

    public void IncrementPlayerScore()
    {
        playerCurrentScore++;

        SetScoreDisplay();
    }

    public void ResetPlayerScore()
    {
        playerCurrentScore = 0;

        SetScoreDisplay();
    }
    void OnDisable()
    {
        SaveHighScore();
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetFloat(highScoreKey, highScoreValue);
        PlayerPrefs.Save();
    }

}
