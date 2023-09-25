using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (GetComponent<MeshRenderer>().material.color == other.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            GameManager.instance.Win();
            Object.Destroy(gameObject);

        }
    }
}
