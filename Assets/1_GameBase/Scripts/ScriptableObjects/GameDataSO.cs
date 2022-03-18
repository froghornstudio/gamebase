using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VGame {
    //[CreateAssetMenu]
    public class GameDataSO : ScriptableObject {
        public bool debugging = false;
        public int camZoom = 5;
        public float textTypingSpeed = 0.5f;

        public enum Languages { en, sp, jp, ru, fr }
        public Languages language = default;

        [Header("Audio Volumes")]
        public float masterMaxVolume = 1;
        public float musicMaxVolume = 0.40f;
        public float soundfxMaxVolume = 1;
        public float voiceMaxVolume = 1;

        [Header("Default Audio Volumes")]
        public const float default_masterMaxVolume = 1;
        public const float default_musicMaxVolume = 0.40f;
        public const float default_soundfxMaxVolume = 1;
        public const float default_voiceMaxVolume = 1;

    }
}