using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorToGrayscale : MonoBehaviour
{
    public float duration = 3.0f;
    private float timer = 0.0f;

    private Material material;
    private Color originalColor; // Store the original color

    void Start()
    {
        material = GetComponent<Renderer>().material;
        originalColor = material.color; // Store the original color when the script starts
    }

    void Update()
    {
        if (timer < duration)
        {
            timer += Time.deltaTime;
            float lerpValue = timer / duration;

            Color targetColor = Color.gray; // Always set to grayscale
            if (GetComponent<ColorToggleButton>().IsColorActive)
            {
                // If the color should be active, lerp to the original color
                targetColor = originalColor;
            }

            material.color = Color.Lerp(material.color, targetColor, lerpValue);

            if (lerpValue >= 1.0f)
            {
                timer = 0.0f;
            }
        }
    }
}
