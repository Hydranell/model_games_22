using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    string lastHitName = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

/*        if(Physics.Raycast(ray, out hit) && hit.rigidbody != null)
        {

            //hit.rigidbody.AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
            hit.rigidbody.AddForceAtPosition(new Vector3(0, 2, 0),hit.point, ForceMode.Impulse);

        }*/

        if (Physics.Raycast(ray, out hit) && hit.rigidbody != null && Input.GetMouseButtonDown(0))
        {

            //hit.rigidbody.AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
            hit.rigidbody.AddForceAtPosition(new Vector3(0, 15, 0), hit.point, ForceMode.Impulse);

        }

      //  if (Physics.Raycast(ray, out hit) && hit.rigidbody != null && Input.GetMouseButton(0))
      //  {
      //
      //      hit.rigidbody.transform.position(new Vector3(Input.mousePosition.x, 0, 0));
      //
      //  }


    }
}
