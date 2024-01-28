using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    public float force = 1.0f;

    private Rigidbody rb;
    //private AudioSource audioSource;

    private RandomAudioClip rac;

    private bool isScoring;

    public GameManager gm;

    private void Start()
    {
        force = Random.Range(3f, 5f);
        rb = GetComponent<Rigidbody>();
        //audioSource = GetComponent<AudioSource>();

        rac = GetComponent<RandomAudioClip>();

        isScoring = false;

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (transform.position.y < -15)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 direction = transform.position - other.transform.position;
            Bounce(direction);

            if (!isScoring)
            {
                StartCoroutine(ScoreTime());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isScoring)
        {
            Vector3 direction = transform.position - collision.GetContact(0).point;
            Bounce(direction);
        }
    }


    private void Bounce(Vector3 direction)
    {
        direction.y = 0.5f;
        rb.AddForce(direction * force, ForceMode.Impulse);
        //audioSource.Play();
        gm.happiness++;

        rac.PlayRandomTrack();
    }


    private IEnumerator ScoreTime()
    {
        isScoring = true;
        yield return new WaitForSeconds(3f);
        isScoring = false;
    }
}
