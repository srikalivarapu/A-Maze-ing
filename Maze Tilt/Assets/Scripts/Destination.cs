using UnityEngine;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour
{
    public GameObject againtext;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Sphere")
        {
            MeshRenderer thisMeshRenderer = GetComponent<MeshRenderer>();
            MeshRenderer otherMeshRenderer = other.gameObject.GetComponent<MeshRenderer>();

            if (thisMeshRenderer != null && otherMeshRenderer != null &&
                thisMeshRenderer.material.color == otherMeshRenderer.material.color)
            {
                SceneManager.LoadScene(2);
                Destroy(gameObject);
            }
            else if (thisMeshRenderer.material.color != otherMeshRenderer.material.color)
            {
                againtext.SetActive(true);
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        againtext.SetActive(false);
    }
}
