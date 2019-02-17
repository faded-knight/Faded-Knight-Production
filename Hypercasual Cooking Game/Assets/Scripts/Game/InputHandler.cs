using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

    private bool currentlyDrawing;

    private Vector2 initialPosition;
    private Vector2 endPosition;

    public GameObject trampolineObject;

    private TrampolineScript currentTrampolineScript;

    [Range (3, 15)]
    public int maximumTrampolineCount = 5;

    public bool trampolinesFull = false;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;

        currentlyDrawing = false;
	}
	
	// Update is called once per frame
	void Update () {
        TakeMouseInput();
        TakeTouchInput();
	}

    void TakeTouchInput()
    {
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
                FinalizeTrampoline();
        	}
		}
    }

    void TakeMouseInput()
    {
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
            FinalizeTrampoline();
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

    void FinalizeTrampoline()
    {
        currentlyDrawing = false;
    }

    public void FreeTrampoline()
    {
        trampolinesFull = false;
    }

    //void SpawnTrampolineObject()
    //{
    //    int activeTrampolines = GameObject.FindGameObjectsWithTag("Trampoline").Length;

    //    if (activeTrampolines < maximumTrampolineCount)
    //    {
    //        if (Vector2.Distance(initialPosition, endPosition) > minimumTrampolineSize)
    //        {
    //            GameObject tramp = (GameObject)Instantiate(trampolineObject);
    //            tramp.GetComponent<TrampolineScript>().InitializeDimensions(initialPosition, endPosition);
    //        }
    //    }
       
    //}
}
