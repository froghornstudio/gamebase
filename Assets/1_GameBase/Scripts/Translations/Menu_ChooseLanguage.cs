using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VGame {
    public class Menu_ChooseLanguage : MonoBehaviour {
        
        public void Switch_English() {
            GameMaster.GetSO<GameDataSO>().language = GameDataSO.Languages.en;
            GameMaster.SaveGameData();
            TRS.i.ChangeLanguage();
            SceneManager.LoadScene("5_Warnings");
        }

        public void Switch_Spanish() {
            GameMaster.GetSO<GameDataSO>().language = GameDataSO.Languages.sp;
            GameMaster.SaveGameData();
            TRS.i.ChangeLanguage();
            SceneManager.LoadScene("5_Warnings");
        }

        public void Switch_Japan() {
            GameMaster.GetSO<GameDataSO>().language = GameDataSO.Languages.jp;
            GameMaster.SaveGameData();
            TRS.i.ChangeLanguage();
            SceneManager.LoadScene("5_Warnings");
        }

        public void Switch_Russian() {
            GameMaster.GetSO<GameDataSO>().language = GameDataSO.Languages.ru;
            GameMaster.SaveGameData();
            TRS.i.ChangeLanguage();
            SceneManager.LoadScene("5_Warnings");
        }

        public void Switch_French() {
            GameMaster.GetSO<GameDataSO>().language = GameDataSO.Languages.fr;
            GameMaster.SaveGameData();
            TRS.i.ChangeLanguage();
            SceneManager.LoadScene("5_Warnings");
        }

    }
}