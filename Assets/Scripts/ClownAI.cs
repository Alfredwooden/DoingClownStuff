using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditorInternal;
using UnityEngine;

public class ClownAI : MonoBehaviour
{
    bool chasing = false;
    AudioListener listener;
    public float moveSpeed = 1.0f;
    public float stoppingDistance = 0.01f;

    //For use with an empty gameobject to quickly move our clown to the default starting chase position
    private GameObject activeOrientationPlaceholder;
    private Collider collider;

    private GameObject player;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!chasing) { return; }
        if (Vector3.Distance(transform.position, player.transform.position) > stoppingDistance)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    //Triggered once player honks first time
    private void AggroClown()
    {
        resetOrientation();
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
