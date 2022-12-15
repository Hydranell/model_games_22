using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miramax
{

    public class MoveToMouse : MonoBehaviour
    {
        public float maxMoveSpeed = 10;
        public float smoothTime = 0.3f;
        public float minDistance = 2;
        Vector3 currentVelocity;
        void Update()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Offsets the target position so that the object keeps its distance.
            mousePosition += ((Vector3)transform.position - mousePosition).normalized * minDistance;
            transform.position = Vector3.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
        }
    }

}


/*
public class MoveToMouse : MonoBehaviour
{
    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    public float minDistance = 2;
    Vector3 currentVelocity;
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Offsets the target position so that the object keeps its distance.
        mousePosition += ((Vector3)transform.position - mousePosition).normalized * minDistance;
        transform.position = Vector3.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
    }
}

*/