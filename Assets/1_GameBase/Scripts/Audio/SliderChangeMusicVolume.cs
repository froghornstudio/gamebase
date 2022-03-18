using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace VGame {
    public class SliderChangeMusicVolume : MonoBehaviour {
        public Slider slider;
        public TextMeshProUGUI tmp;

        private void Start() {
            slider.value = GameMaster.GetSO<GameDataSO>().musicMaxVolume;

            tmp.text = Lng.menus[17].ToString() + " " + (int)(slider.value * 100) + "%";
        }


        public void OnChangedSlider() {
            GameMaster.GetSO<GameDataSO>().musicMaxVolume = slider.value;
            AudioSRC_Music.instance.changeMaxVolume(slider.value);

            tmp.text = Lng.menus[17].ToString() + " " + (int)(slider.value * 100) + "%";
        }

    }
}