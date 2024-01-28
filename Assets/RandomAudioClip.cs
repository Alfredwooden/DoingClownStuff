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

    // Randomly plays audio track from list
    public void PlayRandomTrack()
    {
        if (audioSource == null && clips.Count > 0) { return; }
        int p = Random.Range(0, clips.Count);

        audioSource.clip = clips[p];
        audioSource.Play();
    }
}
