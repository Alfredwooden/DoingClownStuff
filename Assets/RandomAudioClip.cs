using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioClip : MonoBehaviour
{

    [SerializeField]
    private List<AudioClip> clips = new List<AudioClip>();

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
}
