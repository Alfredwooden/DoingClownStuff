using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    public float force = 1.0f;

    private Rigidbody rb;
    private Vector3 direction;
    private AudioSource audioSource;

    public GameManager gm;

    private void Start()
    {
        force = 6f;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision: " + collision.GetContact(0).point);
        if (collision.GetContact(0).point.y > 0.1f)
        {
            direction = transform.position - collision.GetContact(0).point;
            direction.y = 0.75f;
            rb.AddForce(direction * force, ForceMode.Impulse);
            audioSource.Play();
            gm.happiness++;
        }
    }
}
