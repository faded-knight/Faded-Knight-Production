using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
    //String References
    [HideInInspector]
    public string currentFallenIngredient;

    //List References
    public Sprite[] ingredientSprites;

    //Script References
    SpawnerScript bouncerSpawn;
    ScoreUIScript scoreUI;

    //Private GameObject References
    private GameObject recipeUI;

    //Public Bool References
    [HideInInspector]
    public bool recipeComplete;

    //Private Bool References
    private bool recipeSelected;
    
    //Public Int References
    public int nextRecipe;

    //Private Int References
    private int currentIngredients;
    private int recipeProgress;

    //Private Int References
    [Tooltip("Determines the current selected recipe for the game. Do not edit this number")]
    public int currentRecipe;
    
    [Header("Recipe Ingredients")]
    //Image Component References
    public Image ingredient1;
    public Image ingredient2;
    public Image ingredient3;

    // Start is called before the first frame update
    public void Start()
    {
        recipeUI = GameObject.Find("RecipeUI");
        bouncerSpawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnerScript>();
        recipeComplete = false;
        currentRecipe = -1;
        DecideNextRecipe();

    }

    //UGHHHHH PROGRAMMING SUCKS

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
        recipeComplete = false;


        DecideNextRecipe();
    }

    //Loads in the next Recipe in the game
    public void RecipeManager()
    {

        int maxCounter1 = 1;
        int maxCounter2 = 2;
        int maxCounter3 = 3;

        int currentr1 = 0;
        int currentr2 = 0;
        int currentr3 = 0;

        //Used to load the determined recipe into the game.
        switch (nextRecipe)
        {
            //Tomato Soup Recipe
            default:
                if (!recipeSelected)
                {
                    currentRecipe = 0;

                    //Sets Recipe Requirements to Current Recipe
                    ingredient1.sprite = recipeList[currentRecipe].ingredients[0].GetComponentInChildren<SpriteRenderer>().sprite;
                    ingredient2.sprite = recipeList[currentRecipe].ingredients[1].GetComponentInChildren<SpriteRenderer>().sprite;
                    ingredient3.sprite = recipeList[currentRecipe].ingredients[2].GetComponentInChildren<SpriteRenderer>().sprite;
                }
                else
                {
                    //Simplification of referencing recipe items
                    string r1 = recipeList[currentRecipe].ingredients[0].name;
                    string r2 = recipeList[currentRecipe].ingredients[1].name;
                    string r3 = recipeList[currentRecipe].ingredients[2].name;

                    //Checks if currentFallenRecipe == r1 r2 or r3. If true, Add to int
                    if ((currentFallenIngredient == r1 && currentr1 < maxCounter3) || (currentFallenIngredient == r2 && currentr1 < maxCounter3) || (currentFallenIngredient == r3 && currentr1 < maxCounter3))
                    {
                        recipeProgress++;
                        if (currentFallenIngredient.Contains("Tomato"))
                        {
                            currentr1++;
                        }
                    }
                    else
                    {
                        bouncerSpawn.lives--;
                        scoreUI.SetScoreDisplay();
                        
                    }

                    if (recipeProgress >= 3)
                    {
                        recipeProgress = 0;
                        currentr1 = 0;
                        scoreUI.IncrementPlayerScore();

                        DecideNextRecipe();
                    }
                }
                break;

            //Tofu & Vegetable Soup Recipe
            case 1:
                if (!recipeSelected)
                {
                    currentRecipe = 1;

                    //Sets Recipe Requirements to Current Recipe
                    ingredient1.sprite = recipeList[currentRecipe].ingredients[0].GetComponentInChildren<SpriteRenderer>().sprite;
                    ingredient2.sprite = recipeList[currentRecipe].ingredients[1].GetComponentInChildren<SpriteRenderer>().sprite;
                    ingredient3.sprite = recipeList[currentRecipe].ingredients[2].GetComponentInChildren<SpriteRenderer>().sprite;
                }
                else
                {
                    //Simplification of referencing recipe items
                    string r1 = recipeList[currentRecipe].ingredients[0].name;
                    string r2 = recipeList[currentRecipe].ingredients[1].name;
                    string r3 = recipeList[currentRecipe].ingredients[2].name;

                    //Checks if currentFallenRecipe == r1 r2 or r3. If true, Add to int
                    if ((currentFallenIngredient == r1 && currentr1 < maxCounter1) || (currentFallenIngredient == r2 && currentr2 < maxCounter1) || (currentFallenIngredient == r3 && currentr3 < maxCounter1))
                    {
                        recipeProgress++;

                        if (currentFallenIngredient.Contains("Carrot"))
                        {
                            currentr1++;
                        }
                        else if (currentFallenIngredient.Contains("Tofu"))
                        {
                            currentr2++;
                        }
                        else if (currentFallenIngredient.Contains("Celery"))
                        {
                            currentr3++;
                        }
                    }
                    else
                    {
                        bouncerSpawn.lives--;
                        scoreUI.SetScoreDisplay();
                    }

                    if (recipeProgress >= 3)
                    {
                        recipeProgress = 0;
                        currentr1 = 0;
                        currentr2 = 0;
                        currentr3 = 0;
                        scoreUI.IncrementPlayerScore();

                        DecideNextRecipe();
                    }
                }
                break;

                //Carrot Soup Recipe
            case 2:
                if (!recipeSelected)
                {
                    currentRecipe = 2;

                    //Sets Recipe Requirements to Current Recipe
                    ingredient1.sprite = recipeList[currentRecipe].ingredients[0].GetComponentInChildren<SpriteRenderer>().sprite;
                    ingredient2.sprite = recipeList[currentRecipe].ingredients[1].GetComponentInChildren<SpriteRenderer>().sprite;
                    ingredient3.sprite = recipeList[currentRecipe].ingredients[2].GetComponentInChildren<SpriteRenderer>().sprite;

                }
                else
                {
                    //Simplification of referencing recipe items
                    string r1 = recipeList[currentRecipe].ingredients[0].name;
                    string r2 = recipeList[currentRecipe].ingredients[1].name;
                    string r3 = recipeList[currentRecipe].ingredients[2].name;

                    //Checks if currentFallenRecipe == r1 r2 or r3. If true, Add to int
                    if ((currentFallenIngredient == r1 && currentr1 < maxCounter1) || (currentFallenIngredient == r2 && currentr1 < maxCounter1) || (currentFallenIngredient == r3 && currentr2 < maxCounter1))
                    {
                        recipeProgress++;
                        if (currentFallenIngredient.Contains("Carrot"))
                        {
                            currentr1++;
                        }
                        else if (currentFallenIngredient.Contains("Celery"))
                        {
                            currentr2++;
                        }
                    }
                    else
                    {
                        bouncerSpawn.lives--;
                        scoreUI.SetScoreDisplay();
                    }

                    if (recipeProgress >= 3)
                    {
                        recipeProgress = 0;
                        currentr1 = 0;
                        currentr2 = 0;
                        scoreUI.IncrementPlayerScore();

                        DecideNextRecipe();
                    }
                }
                break;

                //Beef Stock Stew Recipe
            case 3:
                if (!recipeSelected)
                {
                    currentRecipe = 3;

                    //Sets Recipe Requirements to Current Recipe
                    ingredient1.sprite = recipeList[currentRecipe].ingredients[0].GetComponentInChildren<SpriteRenderer>().sprite;
                    ingredient2.sprite = recipeList[currentRecipe].ingredients[1].GetComponentInChildren<SpriteRenderer>().sprite;
                    ingredient3.sprite = recipeList[currentRecipe].ingredients[2].GetComponentInChildren<SpriteRenderer>().sprite;
                }
                else
                {
                    //Simplification of referencing recipe items
                    string r1 = recipeList[currentRecipe].ingredients[0].name;
                    string r2 = recipeList[currentRecipe].ingredients[1].name;
                    string r3 = recipeList[currentRecipe].ingredients[2].name;

                    //Checks if currentFallenRecipe == r1 r2 or r3. If true, Add to int
                    if ((currentFallenIngredient == r1 && currentr1 < maxCounter1) || (currentFallenIngredient == r2 && currentr2 < maxCounter1) || (currentFallenIngredient == r3 && currentr3 < maxCounter1))
                    {
                        recipeProgress++;

                        if (currentFallenIngredient.Contains("Beef"))
                        {
                            currentr1++;
                        }
                        else if (currentFallenIngredient.Contains("Carrot"))
                        {
                            currentr2++;
                        }
                        else if (currentFallenIngredient.Contains("Brown_Onion"))
                        {
                            currentr3++;
                        }
                    }
                    else
                    {
                        bouncerSpawn.lives--;
                        scoreUI.SetScoreDisplay();
                    }

                    if (recipeProgress >= 3)
                    {
                        recipeProgress = 0;
                        currentr1 = 0;
                        currentr2 = 0;
                        scoreUI.IncrementPlayerScore();

                        DecideNextRecipe();
                    }
                }
                break;

                //Spicy Mushroom Stew Recipe
            case 4:
                if (!recipeSelected)
                {
                    currentRecipe = 4;

                    //Sets Recipe Requirements to Current Recipe
                    ingredient1.sprite = recipeList[currentRecipe].ingredients[0].GetComponentInChildren<SpriteRenderer>().sprite;
                    ingredient2.sprite = recipeList[currentRecipe].ingredients[1].GetComponentInChildren<SpriteRenderer>().sprite;
                    ingredient3.sprite = recipeList[currentRecipe].ingredients[2].GetComponentInChildren<SpriteRenderer>().sprite;
                }
                else
                {
                    //Simplification of referencing recipe items
                    string r1 = recipeList[currentRecipe].ingredients[0].name;
                    string r2 = recipeList[currentRecipe].ingredients[1].name;
                    string r3 = recipeList[currentRecipe].ingredients[2].name;

                    //Checks if currentFallenRecipe == r1 r2 or r3. If true, Add to int
                    if ((currentFallenIngredient == r1 && currentr1 < maxCounter1) || (currentFallenIngredient == r2 && currentr2 < maxCounter1) || (currentFallenIngredient == r3 && currentr3 < maxCounter1))
                    {
                        recipeProgress++;

                        if (currentFallenIngredient.Contains("Chilli"))
                        {
                            currentr1++;
                        }
                        else if (currentFallenIngredient.Contains("Mushroom"))
                        {
                            currentr2++;
                        }
                        else if (currentFallenIngredient.Contains("Potato"))
                        {
                            currentr3++;
                        }
                    }
                    else
                    {
                        bouncerSpawn.lives--;
                        scoreUI.SetScoreDisplay();
                    }

                    if (recipeProgress >= 3)
                    {
                        recipeProgress = 0;
                        currentr1 = 0;
                        currentr2 = 0;
                        currentr3 = 0;
                        scoreUI.IncrementPlayerScore();

                        DecideNextRecipe();
                    }
                }
                break;
                //Chow Mein Recipe
            case 5:
                if (!recipeSelected)
                {
                    currentRecipe = 5;

                    //Sets Recipe Requirements to Current Recipe
                    ingredient1.sprite = recipeList[currentRecipe].ingredients[0].GetComponentInChildren<SpriteRenderer>().sprite;
                    ingredient2.sprite = recipeList[currentRecipe].ingredients[1].GetComponentInChildren<SpriteRenderer>().sprite;
                    ingredient3.sprite = recipeList[currentRecipe].ingredients[2].GetComponentInChildren<SpriteRenderer>().sprite;
                }
                else
                {
                    //Simplification of referencing recipe items
                    string r1 = recipeList[currentRecipe].ingredients[0].name;
                    string r2 = recipeList[currentRecipe].ingredients[1].name;
                    string r3 = recipeList[currentRecipe].ingredients[2].name;

                    //Checks if currentFallenRecipe == r1 r2 or r3. If true, Add to int
                    if ((currentFallenIngredient == r1 && currentr1 < maxCounter1) || (currentFallenIngredient == r2 && currentr2 < maxCounter1) || (currentFallenIngredient == r3 && currentr3 < maxCounter1))
                    {
                        recipeProgress++;

                        if (currentFallenIngredient.Contains("Celery"))
                        {
                            currentr1++;
                        }
                        else if (currentFallenIngredient.Contains("Carrot"))
                        {
                            currentr2++;
                        }
                        else if (currentFallenIngredient.Contains("Capsicum"))
                        {
                            currentr3++;
                        }
                    }
                    else
                    {
                        bouncerSpawn.lives--;
                        scoreUI.SetScoreDisplay();
                    }

                    if (recipeProgress >= 3)
                    {
                        recipeProgress = 0;
                        currentr1 = 0;
                        currentr2 = 0;
                        currentr3 = 0;
                        scoreUI.IncrementPlayerScore();

                        DecideNextRecipe();
                    }
                }
                break;
        }
    }

    //Decides which Recipe will be loaded into the game
    void DecideNextRecipe()
    {
        nextRecipe = Random.Range(0, recipeList.Length);

        currentRecipe = nextRecipe;

        RecipeManager();
    }
}
