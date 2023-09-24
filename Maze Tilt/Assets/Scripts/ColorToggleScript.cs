using UnityEngine;
using UnityEngine.UI;

public class ColorToggleScript : MonoBehaviour
{
    public Toggle colorToggle;

    private Color[][] originalColors;
    private Color[][] currentColors;

    private bool colorsGrayed = false;

    public void Start()
    {
        colorToggle.onValueChanged.AddListener(OnToggleValueChanged);

        // Store both original and current colors at the start
        StoreColors();
    }

    private void StoreColors()
    {
        Renderer[] renderers = FindObjectsOfType<Renderer>();
        originalColors = new Color[renderers.Length][];
        currentColors = new Color[renderers.Length][];

        for (int i = 0; i < renderers.Length; i++)
        {
            originalColors[i] = new Color[renderers[i].materials.Length];
            currentColors[i] = new Color[renderers[i].materials.Length];

            for (int j = 0; j < renderers[i].materials.Length; j++)
            {
                originalColors[i][j] = renderers[i].materials[j].color;
                currentColors[i][j] = renderers[i].materials[j].color;
            }
        }
    }

    private void OnToggleValueChanged(bool newValue)
    {
        colorsGrayed = newValue;

        if (colorsGrayed)
        {
            // Change colors to gray
            SetAllColors(Color.gray);
        }
        else
        {
            // Restore current colors
            SetAllColors(currentColors);
        }
    }

    private void SetAllColors(Color color)
    {
        Renderer[] renderers = FindObjectsOfType<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            Material[] materials = renderers[i].materials;
            for (int j = 0; j < materials.Length; j++)
            {
                materials[j].color = color;
            }
            renderers[i].materials = materials;
        }
    }

    private void SetAllColors(Color[][] colors)
    {
        Renderer[] renderers = FindObjectsOfType<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            Material[] materials = renderers[i].materials;
            for (int j = 0; j < materials.Length; j++)
            {
                materials[j].color = colors[i][j];
            }
            renderers[i].materials = materials;
        }
    }
}
