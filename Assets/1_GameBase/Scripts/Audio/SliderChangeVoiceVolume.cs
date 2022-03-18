using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace VGame {
    public class SliderChangeVoiceVolume : MonoBehaviour {
        public Slider slider;
        public TextMeshProUGUI tmp;

        private void Start() {
            slider.value = GameMaster.GetSO<GameDataSO>().voiceMaxVolume;

            tmp.text = Lng.menus[16].ToString() + " " + (int)(slider.value * 100) + "%";
        }

        public void OnChangedSlider() {
            GameMaster.GetSO<GameDataSO>().voiceMaxVolume = slider.value;
            AudioSRC_Voice.instance.changeMaxVolume(slider.value);

            tmp.text = Lng.menus[16].ToString() + " " + (int)(slider.value * 100) + "%";
        }

    }
}