using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace VGame {
    public class AudioSRC_Music : MonoBehaviour {
        public static AudioSRC_Music instance;

        public AudioSource audioSource;
        public AudioClip myCurrentSong;
        public AudioMixer masterMixer;

        private void Start() {
            instance = this;
            masterMixer.SetFloat("music", Mathf.Log(GameMaster.GetSO<GameDataSO>().musicMaxVolume) * 20);
        }

        public void changeMaxVolume(float volume) {
            masterMixer.SetFloat("music", Mathf.Log(GameMaster.GetSO<GameDataSO>().musicMaxVolume) * 20);
        }

        public void playMusic(AudioClip clip) {
            if (clip == myCurrentSong) { return; }

            myCurrentSong = clip;
            audioSource.clip = clip;
            audioSource.Play();
        }

        public void stopMusic() => audioSource.Stop();
   

    }
}