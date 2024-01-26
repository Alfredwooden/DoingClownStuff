using System.Collections;
using System.Collections.Generic;
// using UnityEditorInternal;
using UnityEngine;

public class ClownAI : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float stoppingDistance = 0.01f;

    private GameObject player;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > stoppingDistance)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
