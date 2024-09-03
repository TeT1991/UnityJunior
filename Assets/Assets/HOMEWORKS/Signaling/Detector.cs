using System;
using UnityEngine;

namespace AlarmForRobber
{
    [RequireComponent(typeof(Collider2D))]
    public class Detector : MonoBehaviour
    {
        private bool _isDetected;
        private Collider2D _collider;

        public event Action<bool> Detected;


        private void Awake()
        {
            Inititalize();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _isDetected = true;
            SendDetectionSignal();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _isDetected = false;
            SendDetectionSignal();
        }

        private void SendDetectionSignal()
        {
            Detected?.Invoke(_isDetected);
        }

        private void Inititalize()
        {
            _isDetected = false;
            _collider = GetComponent<Collider2D>();
        }
    }
}