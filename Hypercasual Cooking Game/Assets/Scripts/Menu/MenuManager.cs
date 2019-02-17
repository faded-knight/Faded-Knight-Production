using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    bool optionsToggle;
    bool storeToggle;

    private GameObject options;
    private GameObject store;

    //References GameObject specifics to entities in scene
    private void Awake()
    {
        options = GameObject.Find("Options Overlay");
        store = GameObject.Find("Game Store Overlay");
    }

    //To Ensure that bools are set to false on game start.
    private void Start()
    {

        optionsToggle = false;
        storeToggle = false;

        Debug.Log(optionsToggle);
        Debug.Log(storeToggle);
    }

    // Launches the Game
    public void Play()
    {
        Debug.Log("Game Start!");

        SceneManager.LoadScene(1);
    }

    //Toggles the Options Screen on, Containing Sound Effect and Music Toggles
    public void OptionsToggle()
    {
        if (!optionsToggle)
        {
            Debug.Log("Options On");
            gameObject.SetActive(true);
            optionsToggle = true;
            Debug.Log(optionsToggle);
        }
        else
        {
            Debug.Log("Options Off");
            gameObject.SetActive(false);
            optionsToggle = false;
            Debug.Log(optionsToggle);
        }
    } 

    //Toggles the Store Panel, Containing Freemium Asset purchases
    public void StoreToggle()
    {
        if (!storeToggle)
        {
            Debug.Log("Store On");
            gameObject.SetActive(true);
            storeToggle = true;
            Debug.Log(storeToggle);
        }
        else
        {
            Debug.Log("Store Off");
            gameObject.SetActive(false);
            storeToggle = false;
            Debug.Log(storeToggle);
        }
    }
}
