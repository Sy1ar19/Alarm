using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    public float maxVolume = 1f;
    public float fadeTime = 1f;

    [SerializeField] private AudioSource audioSource;
    private bool isInHouse = false;
    private float targetVolume = 0f;

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource.Play();
            isInHouse = true;
            targetVolume = maxVolume;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInHouse = false;
            targetVolume = 0f;
        }
    }

    private void Update()
    {
        audioSource.volume = Mathf.MoveTowards(audioSource.volume, targetVolume, Time.deltaTime / fadeTime);
    }
}
