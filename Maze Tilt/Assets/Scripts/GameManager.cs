using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject winText;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null) {
            Destroy(gameObject);
        }
    }
    public void Win() {
        winText.SetActive(true);
    }
}
