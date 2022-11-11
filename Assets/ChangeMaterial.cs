using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour
{

    // put the first material here.
    public Material material1;
    // put the second material here.
    public Material material2;
    bool FirstMaterial = true;
    bool SecondndMaterial = false;
    void Start()
    {
        transform.GetComponent<MeshRenderer>().material = material1;
    }

    void OnMouseDown()
    {
        if (FirstMaterial)
        {
            transform.GetComponent<MeshRenderer>().material = material2;
            SecondndMaterial = true;
            FirstMaterial = false;
        }
        else if (SecondndMaterial)
        {
            transform.GetComponent<MeshRenderer>().material = material1;
            FirstMaterial = true;
            SecondndMaterial = false;
        }
    }
}