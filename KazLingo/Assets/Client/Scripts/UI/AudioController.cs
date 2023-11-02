using System;
using UnityEngine;

namespace Client.Scripts.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField] private AudioClip _trueSound;
        [SerializeField] private AudioClip _falseSound;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayTrueSound()
        {
            _audioSource.PlayOneShot(_trueSound);
        }
        
        public void PlayFalseSound()
        {
            _audioSource.PlayOneShot(_falseSound);
        }
    }
}