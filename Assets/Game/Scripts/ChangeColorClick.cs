using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorClick : MonoBehaviour
{
    public Material material1;
    public Material material2;

    void Start()
    {
        transform.GetComponent<MeshRenderer>().material = material1;
    }

    void OnMouseDown()
    {
        transform.GetComponent<MeshRenderer>().material = material1;
        //wait
        transform.GetComponent<MeshRenderer>().material = material2;
    }

    /*    IEnumerator CoUpdate()
        {
            if (OnMouseDown == true)
            {
                transform.GetComponent<MeshRenderer>().material = material1;
                yield return new WaitForSeconds(1);
                transform.GetComponent<MeshRenderer>().material = material2;
            }
            yield return null;
        }*/

}

 
