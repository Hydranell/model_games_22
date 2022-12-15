 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miramax
{
    public class FollowTarget : MonoBehaviour
    {

        [SerializeField] private GameObject target;
        [SerializeField] private GameObject center;
        [SerializeField] private float radius;
        [SerializeField] private float speed = 3.5f;
        [SerializeField] private float rotSpeed = 1.75f;

        private bool connected = false;
        private Vector3 direction;
        private Quaternion lookRotation;


        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            //New Moving Script Tryout
            // Vector3 DisClo = Vector3.magnitude(Vector3(target.transform.position - center.transform.position) + Vector3.Normalize(target.transform.position - center.transform.position) * radius * 1.25)

            // TargetCenter + (Kugel-TargetCenter) + (Kugel-TargetCenter)normalize * Kugelradius * 1.25

            /*        target.transform
            */

            //old Moving Script:
            if (connected)
            {
                direction = (center.transform.position - target.transform.position).normalized;
                lookRotation = Quaternion.LookRotation(direction);
                target.transform.rotation = Quaternion.Slerp(
                    target.transform.rotation,
                    lookRotation,
                    Time.deltaTime * rotSpeed
                );
                target.transform.position = Vector3.MoveTowards(
                    target.transform.position,
                    center.transform.position,
                    speed * Time.deltaTime
                );
            }
            else
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    target.transform.position,
                    speed * Time.deltaTime
                );
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == target)
            {
                transform.parent = target.transform;
                connected = true;
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject == target)
            {
                transform.parent = null;
                connected = false;
            }
        }
    }
}