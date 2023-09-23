using UnityEngine;

public class BrownBlockade : MonoBehaviour
{
    public Color brownColor;

    private void OnCollisionEnter(Collision collision)
    {
        Renderer renderer = collision.gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            if (renderer.material.color == brownColor)
            {
                gameObject.SetActive(false);
                renderer.material.color = new Color(128f / 255f, 128f / 255f, 128f / 255f);
            }
        }
    }
}
