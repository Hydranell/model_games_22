using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawn;

    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.velocity = new Vector3();
        collision.transform.position = new Vector3(
            respawn.position.x + Random.Range(-2f, 2f), 
            respawn.position.y + Random.Range(-2f, 2f), 
            respawn.position.z + Random.Range(-2f, 2f)
        );
    }
}
