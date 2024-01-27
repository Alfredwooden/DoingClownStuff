using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    public float force = 1.0f;

    private Rigidbody rb;
    private Vector3 direction;
    private AudioSource audioSource;

    private void Start()
    {
        force = 5f;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].point.y > 0.1f)
        {
            direction = transform.position - collision.contacts[0].point;
            direction.y = 0.75f;
            rb.AddForce(direction * force, ForceMode.Impulse);
            audioSource.Play();
        }
    }
}
