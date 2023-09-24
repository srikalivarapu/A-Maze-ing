using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{

    public float repeatTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeState", 1f, repeatTime);
    }

    void ChangeState()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
