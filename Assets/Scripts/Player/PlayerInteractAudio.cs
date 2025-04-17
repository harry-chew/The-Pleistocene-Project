using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts.Player
{
    public class PlayerInteractAudio : MonoBehaviour
    {
        [Header("Interact Audio Source")]
        public AudioSource interactAudioSource;

        private void OnEnable()
        {
            CoreEvents.ItemEvent += OnItemEvent;
        }

        private void OnDisable()
        {
            CoreEvents.ItemEvent -= OnItemEvent;
        }

        private void OnItemEvent(object sender, ItemEventArgs e)
        {
            if (e.eventType == ItemEventType.Collect || e.eventType == ItemEventType.Use)
            {
                if (e.item == null || e.item.interactClip == null)
                    return;

                PlayInteractAudio(e.item.interactClip);
            }
        }

        private void PlayInteractAudio(AudioClip clip)
        {
            interactAudioSource.clip = clip;
            interactAudioSource.pitch = Random.Range(0.8f, 1.2f);
            interactAudioSource.volume = Random.Range(0.9f, 1.1f);
            interactAudioSource.Play();
        }
    }
}
