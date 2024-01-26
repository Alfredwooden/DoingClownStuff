using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class ClownAI : MonoBehaviour
{
    bool chasing = false;
    AudioListener listener;
    public float moveSpeed = 1.0f;
    public float stoppingDistance = 0.01f;

    //For use with an empty gameobject to quickly move our clown to the default starting chase position
    private GameObject activeOrientationPlaceholder;
    private AudioSource audioSource;
    private Collider collider;

    private GameObject player;
    private Vector3 targetPosition;
    private NavMeshAgent clownAgent;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        clownAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!chasing) { return; }

        if (Vector3.Distance(transform.position, player.transform.position) > clownAgent.stoppingDistance)
        {
            clownAgent.destination = player.transform.position;
        }
    }

    //Triggered once player honks first time
    private void AggroClown()
    {
        resetOrientation();
        audioSource.Stop();
        collider.enabled = true;
        chasing = true;
    }

    //For use with an empty gameobject to quickly move our clown to the default starting chase position
    private void resetOrientation()
    {
        transform.position = activeOrientationPlaceholder.transform.position;
        transform.rotation = activeOrientationPlaceholder.transform.rotation;
    }
}
