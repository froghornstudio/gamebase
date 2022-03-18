using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace VGame {
    public class SliderChangeFXVolume : MonoBehaviour {

        public Slider slider;
        public TextMeshProUGUI tmp;

        private void Start() {
            slider.value = GameMaster.GetSO<GameDataSO>().soundfxMaxVolume;

            tmp.text = Lng.menus[18].ToString() + " " + (int)(slider.value * 100) + "%";
        }


        public void OnChangedSlider() {
            GameMaster.GetSO<GameDataSO>().soundfxMaxVolume = slider.value;
            AudioSRC_SFX.instance.changeMaxVolume(slider.value);

            tmp.text = Lng.menus[18].ToString() + " " + (int)(slider.value * 100) + "%";
        }

    }
}