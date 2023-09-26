using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    //public SaturationTransitionController SaturationTransitionController;  

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
        //if (SaturationTransitionController != null)
        //{
        //    //SaturationTransitionController.StartSaturationTransition();
        //}
        //else
        //{
        //    Debug.LogError("SaturationTransitionController reference is missing!");
        //}
    }

    //public void Win()
    //{
    //    SceneManager.LoadScene(2);
    //}
}
