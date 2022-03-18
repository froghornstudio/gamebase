using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace VGame {
    public class AudioSRC_Master : MonoBehaviour {

        public static AudioSRC_Master instance;

        public AudioMixer masterMixer;

        private void Start() {
            instance = this;

            masterMixer.SetFloat("master", Mathf.Log(GameMaster.GetSO<GameDataSO>().masterMaxVolume) * 20);
        }

        public void changeMaxVolume(float volume) {
            masterMixer.SetFloat("master", Mathf.Log(volume) * 20);
        }

    }
}