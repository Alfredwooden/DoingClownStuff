using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class ClownAI : MonoBehaviour
{

    [SerializeField]
    bool chasing;
    AudioListener listener;

    //For use with an empty gameobject to quickly move our clown to the default starting chase position
    private GameObject activeOrientationPlaceholder;
    private AudioSource audioSource;
    private Collider clownCollider;

    private GameObject player;
    private Vector3 targetPosition;
    private NavMeshAgent clownAgent;
    //Change to GameManager
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        clownCollider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        clownAgent = GetComponent<NavMeshAgent>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        chasing = false;
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
        clownCollider.enabled = true;
        chasing = true;
    }

    //For use with an empty gameobject to quickly move our clown to the default starting chase position
    private void resetOrientation()
    {
        transform.position = activeOrientationPlaceholder.transform.position;
        transform.rotation = activeOrientationPlaceholder.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            gm.EndGame();
        }
    }
}
