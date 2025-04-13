using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPP.Scripts.Player
{
    public class PlayerFootsteps : MonoBehaviour
    {
        public AudioSource leftFoot;
        public AudioSource rightFoot;

        public List<AudioClip> footstepClips = new List<AudioClip>();

        private Rigidbody rb;
        private Coroutine footsteps;

        private float timer;
        private bool isMoving;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            isMoving = false;
        }

        private void Update()
        {
            if (rb.velocity == Vector3.zero)
            {
                StopCoroutine(Footstep());
                footsteps = null;
                isMoving = false;
            }
            else
            {
                if (footsteps == null)
                {
                    footsteps = StartCoroutine(Footstep());
                    isMoving = true;
                }
            }

            Vector3 norm = rb.velocity.normalized;
            timer = Mathf.Abs(norm.x) + Mathf.Abs(norm.z);
        }

        private IEnumerator Footstep()
        {
            while (true)
            {
                if (!isMoving)
                    yield break;

                if (leftFoot.isPlaying)
                    yield break;

                AudioClip left = GetRandomFootstep();
                leftFoot.clip = left;
                leftFoot.pitch = GetRandomPitch();
                leftFoot.Play();

                yield return new WaitForSeconds(timer * 0.5f);

                if (!isMoving)
                    yield break;

                if (rightFoot.isPlaying)
                    yield break;

                AudioClip right = GetRandomFootstep();
                rightFoot.clip = right;
                rightFoot.pitch = GetRandomPitch();
                rightFoot.Play();

                yield return new WaitForSeconds(timer * 0.5f);
            }
        }

        private AudioClip GetRandomFootstep()
        {
            int index = Random.Range(0, footstepClips.Count);
            return footstepClips[index];
        }

        private float GetRandomPitch()
        {
            return Random.Range(0.95f, 1.05f);
        }
    }
}
