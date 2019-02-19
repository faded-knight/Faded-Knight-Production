using UnityEngine;
using System.Collections;

public class RecipesScript : MonoBehaviour {

    //GameObject References
    public GameObject recipesUI;

    // Start is called before the first frame update
    void Start()
    {
        recipesUI = GameObject.Find("RecipeUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
