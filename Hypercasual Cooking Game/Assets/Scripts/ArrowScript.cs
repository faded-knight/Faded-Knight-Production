using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

    Renderer spriteRenderer;
    Color colour;

    public float cycleSpeedScale;

    public float transparencyAmplitude;

	// Use this for initialization
	void Start () {
        spriteRenderer = gameObject.GetComponent<Renderer>();
        colour = spriteRenderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
        colour.a = transparencyAmplitude + transparencyAmplitude * Mathf.Sin(Time.time * cycleSpeedScale);
        spriteRenderer.material.color = colour;
	}
}
