using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnSameColor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (GetComponent<MeshRenderer>().material.color == other.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            gameObject.SetActive(false);

        }
    }
}
