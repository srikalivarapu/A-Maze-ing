using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public SaturationTransitionController saturationTransitionController;  // Reference to your SaturationTransitionController

    void Awake()
    {
        // Ensure there's only one instance of the GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object between scenes
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Check if we have a reference to the SaturationTransitionController
        if (saturationTransitionController != null)
        {
            // Start the saturation transition
            saturationTransitionController.StartSaturationTransition();
        }
        else
        {
            Debug.LogError("SaturationTransitionController reference is missing!");
        }
    }

    public void Win()
    {
        SceneManager.LoadScene(2);
    }
}
