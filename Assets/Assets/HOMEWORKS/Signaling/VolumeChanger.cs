using System.Collections;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _targetVolume;
    private float _changingVolumeStep;

    private Coroutine _coroutine;

    public void ChangeTargetVolume(bool isDetected)
    {
        float minValue = 0;
        float maxValue = 1;

        if (isDetected)
        {
            _targetVolume = maxValue;

        }
        else
        {
            _targetVolume = minValue;
        }

        _coroutine = StartCoroutine(ChangeVolume());
    }

    public void Init(AudioSource audioSource)
    {
        _audioSource = audioSource;
        _changingVolumeStep = 0.2f;
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _changingVolumeStep * Time.deltaTime);

            if (_audioSource.volume == _targetVolume)
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }
            }
        }

        yield return null;
    }
}
