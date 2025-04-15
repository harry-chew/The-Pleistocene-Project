using System;
using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts.Player
{
    public class PlayerInteractAudio : MonoBehaviour
    {
        public AudioSource interactAudioSource;
        // Start is called before the first frame update
        void Start()
        {
            CoreEvents.ItemEvent += OnItemEvent;
        }

        private void OnItemEvent(object sender, ItemEventArgs e)
        {
            if (e.eventType == ItemEventType.Collect)
            {
                if (e.item == null || e.item.interactClip == null)
                    return;

                interactAudioSource.clip = e.item.interactClip;
                interactAudioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
                interactAudioSource.volume = UnityEngine.Random.Range(0.9f, 1.1f);
                interactAudioSource.Play();
            }
        }
    }
}
