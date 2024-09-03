using UnityEngine;

namespace AlarmForRobber
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Detector), typeof(VolumeChanger), typeof(AlarmPlayer))]
    public class Alarm : MonoBehaviour
    {
        private AudioSource _audioSource;

        private Detector _detector;
        private VolumeChanger _volumeChanger;
        private AlarmPlayer _player;

        private void Awake()
        {
            Inititalize();
        }

        private void Inititalize()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.volume = 0;

            _player = GetComponent<AlarmPlayer>();
            _player.Init(_audioSource);

            _volumeChanger = GetComponent<VolumeChanger>();
            _volumeChanger.Init(_audioSource);

            _detector = GetComponent<Detector>();
            _detector.Detected += _player.StartOrStopPlaying;
            _detector.Detected += _volumeChanger.ChangeTargetVolume;
        }
    }
}