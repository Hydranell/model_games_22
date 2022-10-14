using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    [SerializeField] private GameObject Target;
    [SerializeField] private GameObject Center;
    [SerializeField] private float Radius;
    [SerializeField] private float speed = 1.5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 DisClo = Vector3.magnitude(Vector3(Target.transform.position - Center.transform.position) + Vector3.Normalize(Target.transform.position - Center.transform.position) * Radius * 1.25)
           // TargetCenter + (Kugel-TargetCenter) + (Kugel-TargetCenter)normalize * Kugelradius * 1.25
        
           //old Moving Script:
           //transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);

        /// Here vektorstuff

    }
}
