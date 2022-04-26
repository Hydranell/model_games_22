using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    [SerializeField] private GameObject Target;
    [SerializeField] private GameObject Center;
    [SerializeField] private float speed = 1.5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);

        //vektor von kugelmitte zu mitte der map (center.obj), dann if collision von cube-kugel then cube um kugel drehen mittelpounkt der drehung = kugelmittelpunkt,
        //zielrichtung negative vektor z x vom kugelmittelpunkt zur map mittelpunkt mit kugelmittelpunkt-cubemittelpunkt als länge

    }

    private void OnCollision(Collision collision)
    {
        if (collision.gameObject == Target) { 

            Vector3 TargetDirection = Vector3.Reflect(Center.transform.position - Target.transform.position, Vector3.up);       //maybe here it lies (neuer vektor der beiden, y = 0 damit es waagrecht wird
            // target direction um magnitude in richtung target direction verschieben
            Vector3 CubeDirection = transform.position - Target.transform.position;
            float angle = Vector3.Angle(CubeDirection, TargetDirection);
            transform.RotateAround(Target.transform.position, Vector3.up, angle * Time.deltaTime);
        }
    }
}
