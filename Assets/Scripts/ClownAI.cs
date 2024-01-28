using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    private Image clownImage;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        clownCollider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        clownAgent = GetComponent<NavMeshAgent>();
        clownImage = GetComponentInChildren<Image>();
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

        direction = transform.position - player.transform.position;

        if (direction.x > 0 && clownImage.transform.localScale.x < 0)
        {
            clownImage.transform.localScale = new Vector3(clownImage.transform.localScale.x * -1, clownImage.transform.localScale.y, clownImage.transform.localScale.z);
        }
        else if (direction.x < 0 && clownImage.transform.localScale.x > 0)
        {
            clownImage.transform.localScale = new Vector3(clownImage.transform.localScale.x * -1, clownImage.transform.localScale.y, clownImage.transform.localScale.z);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gm.LoseGame();
        }
    }
}
