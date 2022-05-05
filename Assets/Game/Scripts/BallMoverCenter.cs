using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoverCenter : MonoBehaviour
{

    [SerializeField] private GameObject Cube;
    [SerializeField] private GameObject Center;
    [SerializeField] private float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

     
        if (collision.gameObject == Cube)
        {
            //transform.position = Vector3.MoveTowards(transform.position, Center.transform.position, speed * 10 * Time.deltaTime);
            GetComponent<Rigidbody>().AddForce(transform.position - Center.transform.position * speed, ForceMode.Impulse);
        }

    }
}
