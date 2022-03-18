using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace VGame {
    public class SliderChangeMasterVolume : MonoBehaviour {

        public Slider slider;
        public TextMeshProUGUI tmp;

        private void Start() {
            slider.value = GameMaster.GetSO<GameDataSO>().masterMaxVolume;

            tmp.text = Lng.menus[15].ToString() + " " + (int)(slider.value * 100) + "%";
        }


        public void OnChangedSlider() {
            GameMaster.GetSO<GameDataSO>().masterMaxVolume = slider.value;
            AudioSRC_Master.instance.changeMaxVolume(slider.value);

            tmp.text = Lng.menus[15].ToString() + " " + (int)(slider.value * 100) + "%";
        }

    }
}