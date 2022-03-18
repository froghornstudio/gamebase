using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VGame {
    public class MusicPlayer : MonoBehaviour {
        public static MusicPlayer instance;

        [Header("Music Files - Add music files here.")]
        [SerializeField] private AudioClip blank = default;

        [Header("Calculated Current Song")]
        public AudioClip currentSong = default;

        private void Awake() => instance = this;

        private void OnEnable() {
            //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }

        private void OnDisable() {
            //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }

        private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
            //Change Song
            StartCoroutine(LoadSceneSong(scene.name));
        }

        public void ReplayCurrentSong() {
            if (currentSong != null) {
                AudioSRC_Music.instance.playMusic(currentSong);
            }
        }

        private IEnumerator LoadSceneSong(string myscenename) {
            yield return new WaitForSeconds(0.01f);

            //Add logic here to choose songs            
            switch (myscenename) {
                case "SampleScene":
                    currentSong = blank;
                    break;
                default:
                    currentSong = blank;
                    break;
            }

            AudioSRC_Music.instance.playMusic(currentSong);


            yield return true;

        }


    }
}
