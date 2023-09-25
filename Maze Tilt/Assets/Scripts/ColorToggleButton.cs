using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorToggleButton : MonoBehaviour
{
    public string tagToColorize = "ColorChange"; // Set this to the tag you want to colorize
    public float colorDuration = 3.0f;

    private bool isColorActive = false;
    private float colorTimer = 0.0f;
    private Color[] originalColors;
    private GameObject[] objectsToColorize;

    void Start()
    {
        // Find and store the objects to colorize based on the specified tag
        FindObjectsToColorize();
    }

    void Update()
    {
        if (isColorActive)
        {
            colorTimer += Time.deltaTime;

            if (colorTimer >= colorDuration)
            {
                SetColorObjects(false);
                isColorActive = false;
            }
        }
    }

    public void OnButtonClick()
    {
        SetColorObjects(!isColorActive); // Toggle the color state
        colorTimer = 0.0f;
        isColorActive = !isColorActive; // Toggle the flag
    }

    public void FindObjectsToColorize()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tagToColorize);
        objectsToColorize = taggedObjects;

        // Store the original colors of the objects
        originalColors = new Color[objectsToColorize.Length];

        for (int i = 0; i < objectsToColorize.Length; i++)
        {
            Renderer renderer = objectsToColorize[i].GetComponent<Renderer>();
            if (renderer != null)
            {
                originalColors[i] = renderer.material.color;
            }
        }
    }

    public void SetColorObjects(bool isColor)
    {
        for (int i = 0; i < objectsToColorize.Length; i++)
        {
            Renderer renderer = objectsToColorize[i].GetComponent<Renderer>();
            if (renderer != null)
            {
                if (isColor)
                {
                    // Restore the original color
                    renderer.material.color = originalColors[i];
                }
                else
                {
                    // Set the object to grayscale
                    renderer.material.color = Color.gray;
                }
            }
        }
    }

    public bool IsColorActive
    {
        get { return isColorActive; }
    }
}
