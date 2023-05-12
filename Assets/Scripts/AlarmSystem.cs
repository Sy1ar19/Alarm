using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolume = 1f;
    private float _fadeTime = 1f;
    private Coroutine coroutine;
    private float _targetVolume = 0f;

    public void ActivateAlarm()
    {
        _audioSource.Play();
        SetVolume(_maxVolume);
        StopCoroutine();
        coroutine = StartCoroutine(VolumeChange());
    }

    public void DeactivateAlarm()
    {
        SetVolume(0f);
        StopCoroutine();
        coroutine = StartCoroutine(VolumeChange());
    }

    private void SetVolume(float volume)
    {
        _targetVolume = volume;
    }

    private void StopCoroutine()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    private IEnumerator VolumeChange()
    {
        while (_targetVolume != _audioSource.volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, Time.deltaTime / _fadeTime);
            yield return null;
        }
    }
}
