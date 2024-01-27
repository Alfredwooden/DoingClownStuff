using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    public float force = 1.0f;

    private Rigidbody rb;
    private Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        direction = transform.position - collision.contacts[0].point;
        rb.AddForce(direction * force, ForceMode.Impulse);
    }
}
