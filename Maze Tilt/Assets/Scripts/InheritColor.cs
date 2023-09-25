using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritColor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<MeshRenderer>().name != "ColorGate" && other.gameObject.GetComponent<MeshRenderer>().name != "Destination") {
            if (other.gameObject.GetComponent<MeshRenderer>().material.color != Color.white)
            {
                if (GetComponent<MeshRenderer>().material.color == Color.white)
                {
                    GetComponent<MeshRenderer>().material.color = other.gameObject.GetComponent<MeshRenderer>().material.color;
                }
                else
                {
                    GetComponent<MeshRenderer>().material.color = (GetComponent<MeshRenderer>().material.color + other.gameObject.GetComponent<MeshRenderer>().material.color) / 2;
                }


            }
        }
        
    }
        
}
