using UnityEngine;
using System.Collections;

namespace miramax
{
    public class ChangeMaterial : MonoBehaviour
    {
        // put the first material here.
        public Material material1;
        // put the second material here.
        public Material material2;
        bool FirstMaterial = true;
        bool SecondMaterial = false;

        // The amount of time to wait before changing the material back to the original one (in seconds)
        public float delay = 1.0f;

        void Start()
        {
            transform.GetComponent<MeshRenderer>().material = material1;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<ChangeMaterial>() != null)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Impulse);
            }
        }

        void OnMouseDown()
        {
            if (FirstMaterial)
            {
                transform.GetComponent<MeshRenderer>().material = material2;
                SecondMaterial = true;
                FirstMaterial = false;

                // Start a coroutine that will change the material back to the original one after a certain amount of time
                StartCoroutine(ChangeBackAfterDelay());
            }

            /*        else if (SecondMaterial)
                    {
                        transform.GetComponent<MeshRenderer>().material = material1;
                        FirstMaterial = true;
                        SecondMaterial = false;

                        // Start a coroutine that will change the material back to the original one after a certain amount of time
                        StartCoroutine(ChangeBackAfterDelay());
                    }*/
        }

        // This is a coroutine
        IEnumerator ChangeBackAfterDelay()
        {
            // Wait for the specified amount of time
            yield return new WaitForSeconds(delay);

            // Change the material back to the original one
            // transform.GetComponent<MeshRenderer>().material = material1;
            transform.GetComponent<MeshRenderer>().material = material1;
            SecondMaterial = false;
            FirstMaterial = true;

        }
    }
}
