using System.Collections;
using UnityEngine;

namespace AlarmForRobber
{
    [RequireComponent(typeof(AudioSource))]
    public class Alarm : MonoBehaviour
    {
        private AudioSource _audioSource;

        private float _targetVolume;
        private float _changingVolumeStep;
        private float _timeBetweenChanging;

        private bool _isPlaying;

        private Coroutine _coroutine;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Inititalize(); 
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ChangeTargetVolume();
            TryStartPlaying();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            ChangeTargetVolume();
        }

        private void TryStartPlaying()
        {
            if (_isPlaying == false)
            {
                _isPlaying = true;
                _coroutine = StartCoroutine(ChangeVolumeCountdown(_timeBetweenChanging));
                _audioSource.Play();
            }
        }

        private void TryStopPLaying()
        {
            if (_audioSource.volume == 0)
            {
                _audioSource.Stop();
                _isPlaying = false;

                if(_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }
            }
        }

        private void TryChangeVolume()
        {
            if (_isPlaying)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _changingVolumeStep);

                TryStopPLaying();
            }
        }

        private void ChangeTargetVolume()
        {
            float minValue = 0;
            float maxValue = 1;

            if (_targetVolume == minValue)
            {
                _targetVolume = maxValue;
            }
            else
            {
                _targetVolume = minValue;
            }
        }

        private IEnumerator ChangeVolumeCountdown(float delay)
        {
            var wait = new WaitForSeconds(delay);

            while (_isPlaying)
            {
                TryChangeVolume();

                yield return wait;
            }
        }

        private void Inititalize()
        {
            _audioSource = GetComponent<AudioSource>();
            _isPlaying = false;

            _targetVolume = 0;
            _changingVolumeStep = 0.2f;
            _timeBetweenChanging = 1;
        }
    }
}