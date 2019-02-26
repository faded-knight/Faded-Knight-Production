using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RecipesScript : MonoBehaviour {

    //---------------------
    //Script Created By
    // Callum Stirrup-Prazak
    //
    //---------------------
    
    //Recipe control System
    [Header("Recipe Creation List")]

    [Tooltip("The List of Recipes and their ingredients")]
    public Item[] recipeList;
    [System.Serializable]
    public class Item
    {
        //Required items to create the specific ingredient
        [Tooltip("Put any 3 ingredients used in the following recipe")]
        public GameObject[] ingredients;
        [Tooltip("The Name of the Recipe in the game")]
        public string recipeName;
    }

    //Struct References
    public ImageChange[] soupSprites;
    [System.Serializable]
    public struct ImageChange
    {
        [Tooltip("Put the image sprites here")]
        public Sprite ingredientSprites;
        public string ingredientName;

    }

    //Script References
    SpawnerScript bouncerSpawn;

    //Private GameObject References
    private GameObject recipeUI;

    //Public Bool References
    [HideInInspector]
    public bool recipeComplete;

    //Public Int References
    public int nextRecipe;

    //Private Int References
    [SerializeField]
    [Tooltip("Determines the current selected recipe for the game. Do not edit this number")]
    private int currentRecipe;

    //Image Component References
    private Image ingredient1;
    private Image ingredient2;
    private Image ingredient3;


    // Start is called before the first frame update
    public void Start()
    {
        recipeUI = GameObject.Find("RecipeUI");
        bouncerSpawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnerScript>();
        recipeComplete = false;
        currentRecipe = -1;
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
        //Used to load the determined recipe into the game.
        switch (nextRecipe)
        {
            //Tomato Soup Recipe
            default:
                currentRecipe = 0;
                ingredient1.sprite = soupSprites[0].ingredientSprites;
                ingredient2.sprite = soupSprites[0].ingredientSprites;
                ingredient3.sprite = soupSprites[0].ingredientSprites;
                break;
            
            case 1:
                currentRecipe = 1;
                ingredient1.sprite = soupSprites[0].ingredientSprites;
                ingredient2.sprite = soupSprites[0].ingredientSprites;
                ingredient3.sprite = soupSprites[0].ingredientSprites;
                break;

            case 2:
                currentRecipe = 2;
                ingredient1.sprite = soupSprites[0].ingredientSprites;
                ingredient2.sprite = soupSprites[0].ingredientSprites;
                ingredient3.sprite = soupSprites[0].ingredientSprites;
                break;

            case 3:
                currentRecipe = 3;
                ingredient1.sprite = soupSprites[0].ingredientSprites;
                ingredient2.sprite = soupSprites[0].ingredientSprites;
                ingredient3.sprite = soupSprites[0].ingredientSprites;
                break;

            case 4:
                currentRecipe = 4;
                ingredient1.sprite = soupSprites[0].ingredientSprites;
                ingredient2.sprite = soupSprites[0].ingredientSprites;
                ingredient3.sprite = soupSprites[0].ingredientSprites;
                break;

            case 5:
                currentRecipe = 5;
                ingredient1.sprite = soupSprites[0].ingredientSprites;
                ingredient2.sprite = soupSprites[0].ingredientSprites;
                ingredient3.sprite = soupSprites[0].ingredientSprites;
                break;
        }
    }

    //Decides which Recipe will be loaded into the game
    void DecideNextRecipe()
    {
        nextRecipe = Random.Range(0, recipeList.Length);

        LoadRecipe();
    }
}
