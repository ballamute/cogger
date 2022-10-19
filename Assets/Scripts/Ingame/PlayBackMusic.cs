using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource _audioSource;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
