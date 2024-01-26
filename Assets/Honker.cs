using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honker : MonoBehaviour
{
    AudioSource honker;

    // Start is called before the first frame update
    void Start()
    {
        honker = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            honker.Play();
            Debug.Log("Honk");
        }
    }

    void Honk()
    {
        Debug.Log("Honk");
    }
}
