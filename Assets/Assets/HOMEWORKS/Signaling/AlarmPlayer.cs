using UnityEngine;

public class AlarmPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    public void StartOrStopPlaying(bool isDetected)
    {
        if (isDetected)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }

    public void Init(AudioSource audioSource)
    {
        _audioSource = audioSource;
    }
}
