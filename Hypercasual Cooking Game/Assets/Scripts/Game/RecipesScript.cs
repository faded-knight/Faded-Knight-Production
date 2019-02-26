using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RecipesScript : MonoBehaviour {
    
    //Recipe control System
    [Header("Recipe Creation List")]
    public Item[] recipeList;
    [System.Serializable]
    public class Item
    {
        //Required items to create the specific ingredient
        public GameObject[] ingredients;
        public string ingredientName;
    }

    //Script References
    SpawnerScript bouncerSpawn;

    //Private GameObject References
    private GameObject recipeUI;

    //Private Bool References
    private bool recipeComplete;

    // Start is called before the first frame update
    public void Start()
    {
        recipeUI = GameObject.Find("RecipeUI");
        bouncerSpawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnerScript>();
        recipeComplete = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (recipeComplete)
        {
            RecipeComplete();
        }
    }

    //Updates the Score System based on the recipe which is completed
    public void RecipeComplete()
    {



        DecideNextRecipe();
    }

    //Loads in the next Recipe in the game
    void LoadRecipe()
    {

    }

    //Decides which Recipe will be loaded into the game
    void DecideNextRecipe()
    {
        int RandInt;
        RandInt = Random.Range(0, recipeList.Length);


        LoadRecipe();
    }
}
