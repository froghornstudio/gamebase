using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace VGame {
    public class AudioSRC_Voice : MonoBehaviour {
        public static AudioSRC_Voice instance;

        public AudioMixer masterMixer;

        [Header("Audio Sources")]
        public AudioSource audioSource;

        public bool isPlaying = false;
        private bool crisRunning = false;
        private IEnumerator coroutine;

        private bool prevframepaused = false;

        private void Start() {
            instance = this;

            masterMixer.SetFloat("voice", Mathf.Log(GameMaster.GetSO<GameDataSO>().voiceMaxVolume) * 20);
        }

        private void Update() {
            if (isPlaying && GameMaster.paused) {
                audioSource.Pause();
                prevframepaused = true;
            }

            if (prevframepaused && !GameMaster.paused) {
                audioSource.UnPause();
                prevframepaused = false;
            }

        }


        public void changeMaxVolume(float volume) {
            masterMixer.SetFloat("voice", Mathf.Log(volume) * 20);
        }

        public void playDialogue(AudioClip clip) {
            audioSource.clip = clip;
            audioSource.Play();

            if (crisRunning) {
                crisRunning = false;
                isPlaying = false;
                StopCoroutine(coroutine);
            }

            coroutine = CheckifIsPlaying(clip.length);
            StartCoroutine(coroutine);
        }


        private IEnumerator CheckifIsPlaying(float mylength) {
            crisRunning = true;
            isPlaying = true;
            yield return new WaitForSeconds(mylength);           
            crisRunning = false;
            isPlaying = false;
            yield return true;
        }


        public void StopDialogue() {
            if (crisRunning) {
                StopCoroutine(coroutine);
            }          
            audioSource.Stop();
            isPlaying = false;
        }

    }
}
