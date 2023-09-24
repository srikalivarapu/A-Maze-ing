using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
