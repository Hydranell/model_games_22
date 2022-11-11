using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour
{

    // put the first material here.
    public Material material1;
    // put the second material here.
    public Material material2;
    bool FirstMaterial = true;
    bool SecondMaterial = false;
    void Start()
    {
        transform.GetComponent<MeshRenderer>().material = material1;
    }

    void OnMouseDown()
    {
        if (FirstMaterial)
        {
            transform.GetComponent<MeshRenderer>().material = material2;
            SecondMaterial = true;
            FirstMaterial = false;
        }
        else if (SecondMaterial)
        {

            transform.GetComponent<MeshRenderer>().material = material1;
            FirstMaterial = true;
            SecondMaterial = false;
        }
    }
}