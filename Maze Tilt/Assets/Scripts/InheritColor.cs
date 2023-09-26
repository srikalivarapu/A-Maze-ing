using UnityEngine;

public class InheritColor : MonoBehaviour
{
    public SaturationTransitionController saturationTransitionController; // Assign in the Inspector

    private void OnCollisionEnter(Collision other)
    {
        MeshRenderer otherMeshRenderer = other.gameObject.GetComponent<MeshRenderer>();

        if (otherMeshRenderer != null)
        {
            if (otherMeshRenderer.name != "ColorGate" && otherMeshRenderer.name != "Destination")
            {
                if (otherMeshRenderer.material.color != Color.white)
                {
                    MeshRenderer thisMeshRenderer = GetComponent<MeshRenderer>();
                    if (thisMeshRenderer != null)
                    {
                        Color otherColor = otherMeshRenderer.material.color;
                        Color thisColor = thisMeshRenderer.material.color;

                        if (thisColor == Color.white)
                        {
                            thisMeshRenderer.material.color = otherColor;
                        }
                        else
                        {
                            thisMeshRenderer.material.color = (thisColor + otherColor) / 2;
                        }
                    }
                }
            }
            else if (otherMeshRenderer.name == "ColorGate" && saturationTransitionController != null)
            {
                // Call StartSaturationTransition function when hitting the ColorGate
                saturationTransitionController.StartSaturationTransition();
            }
        }
    }
}
