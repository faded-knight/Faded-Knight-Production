using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

    //Script References
    TrampolineScript currentTrampolineScript;
    
    //public Object References
    public GameObject trampolineObject;

    //public bool Variables
    public bool trampolinesFull = false;

    //private bool Variables
    private bool currentlyDrawing;
    public bool breakableTrampolines;

    //private Vector2 References
    private Vector2 initialPosition;
    private Vector2 endPosition;

    //Public Int Variables
    [Range (3, 15)]
    public int maximumTrampolineCount = 5;


	// Use this for initialization
	void Start () {
        
		Application.targetFrameRate = 60;

        currentlyDrawing = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GameInputManager();
	}

    void GameInputManager()
    {
        //Mobile Touch Input
		if (Input.touchCount > 0)
		{
        	if (Input.GetTouch(0).phase == TouchPhase.Began && !currentlyDrawing)
        	{
            	StartDrawing(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
        	}
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && currentlyDrawing && currentTrampolineScript != null && !trampolinesFull)
            {
                UpdateCurrentTrampoline(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
            }
        	else if (Input.GetTouch(0).phase == TouchPhase.Ended)
        	{
                currentlyDrawing = false;
        	}
		}

        //Mouse Click Input
        if (Input.GetMouseButtonDown(0) && !currentlyDrawing)
        {
            StartDrawing(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else if (Input.GetMouseButton(0) && currentlyDrawing && currentTrampolineScript != null && !trampolinesFull)
        {
            UpdateCurrentTrampoline(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            currentlyDrawing = false;
        }
    }

    void StartDrawing(Vector2 location)
    {
        currentlyDrawing = true;
        int activeTrampolines = GameObject.FindGameObjectsWithTag("Trampoline").Length;

        if (activeTrampolines < maximumTrampolineCount)
        {
            GameObject tramp = (GameObject)Instantiate(trampolineObject, location, new Quaternion());
            currentTrampolineScript = tramp.GetComponent<TrampolineScript>();
            initialPosition = location;
        }
        else
        {
            trampolinesFull = true;
        }
    }

    void UpdateCurrentTrampoline(Vector2 location)
    {
        currentTrampolineScript.InitializeDimensions(initialPosition, location);
    }
}
