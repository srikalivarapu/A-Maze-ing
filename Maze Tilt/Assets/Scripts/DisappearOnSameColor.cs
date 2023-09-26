using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnSameColor : MonoBehaviour
{
    [SerializeField] public GameObject againtext;
    private void OnCollisionEnter(Collision other)

    {
        if (GetComponent<MeshRenderer>().material.color == other.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            gameObject.SetActive(false);
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            againtext.SetActive(false);

        }
    }
}
