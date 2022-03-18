using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VGame {
    public class TRS : MonoBehaviour {

        public static TRS i;

        public Lng rlang;

        private void Awake() {
            i = this;
          
            ChangeLanguage();
        }

        public void ChangeLanguage() {           
            switch (GameMaster.GetSO<GameDataSO>().language) {
                case GameDataSO.Languages.en:
                    rlang = new en();
                    break;
                case GameDataSO.Languages.sp:
                    rlang = new sp();
                    break;
                case GameDataSO.Languages.jp:
                    rlang = new jp();
                    break;
                default:
                    rlang = new en();
                    break;
            }
            rlang.Run();
        }


    }
}