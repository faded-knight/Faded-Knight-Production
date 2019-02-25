using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RecipesScript : MonoBehaviour {

    //Script References
    SpawnerScript bouncerSpawn;

    //GameObject References
    private GameObject recipeUI;

    // Start is called before the first frame update
    public void Start()
    {
        recipeUI = GameObject.Find("RecipeUI");
        bouncerSpawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnerScript>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
