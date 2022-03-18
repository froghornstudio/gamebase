using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace VGame {
    public static class GameMaster {
       
        public static bool paused = false;

        #region Premade Load, Delete and Save Functions
        public static int CurrentSlot = 1;

        //Game System Vars
        public static void LoadGameData() => LoadData("GameData", GetSO<GameDataSO>(), 1);
        public static void SaveGameData() => SaveData("GameData", GetSO<GameDataSO>(), 1);
        public static void DeleteGameData() => DeleteData("GameData", 1);

        //Player and Game State
        public static void LoadPlayerSO(int slotNum) => LoadData("PlayerData", GetSO<PlayerSO>(), slotNum);
        public static void SavePlayerSO() {
            GetSO<PlayerSO>().saveFileVersion = Application.version;
            SaveData("PlayerData", GetSO<PlayerSO>(), CurrentSlot);
        }
        public static void DeletePlayerSO(int slotNum) => DeleteData("PlayerData", slotNum);

        #endregion

        //Slots for temporaryily loading SO stuff.
        public static PlayerSO bandaidSlotA, bandaidSlotB, bandaidSlotC, bandaidBlank;

        //Bool to only allow to Load only once
        public static bool inited = false;

        //Automatic Loading of prefabs and SO dictionary.
        private static Dictionary<Type, ScriptableObject> soInstances = new Dictionary<Type, ScriptableObject>();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void SpawnAllSingletons() {
            if (inited) { return; }

            //Load Scriptable Objects
            var scriptableObjects = Resources.LoadAll<ScriptableObject>("Singletons");
            foreach (var so in scriptableObjects) {
                var type = so.GetType();
                var runtimeCopy = ScriptableObject.Instantiate(so);
                soInstances.Add(type, runtimeCopy);
            }

            //Load Translator first
            var trans = Resources.Load<GameObject>("Translator");
            GameObject.Instantiate(trans);
            GameObject.DontDestroyOnLoad(trans);
            TRS.i.ChangeLanguage();


            //Load prefabs in Singletons folder
            var prefabs = Resources.LoadAll<GameObject>("Singletons");
            foreach (var p in prefabs) {
                var instance = GameObject.Instantiate(p);
                GameObject.DontDestroyOnLoad(instance);
            }

            bandaidSlotA = ScriptableObject.Instantiate(GetSO<PlayerSO>());
            bandaidSlotB = ScriptableObject.Instantiate(GetSO<PlayerSO>());
            bandaidSlotC = ScriptableObject.Instantiate(GetSO<PlayerSO>());
            bandaidBlank = ScriptableObject.Instantiate(GetSO<PlayerSO>());

            //Done
            inited = true;
        }

        //SO Reference Method
        public static T GetSO<T>() where T : ScriptableObject {
            var type = typeof(T);
            return (T)soInstances[type];
        }

        public static void ResetGameDataSO(string filename = "GameData", int slot = 1) {
            var origGameDataSO = Resources.Load<GameDataSO>("Singletons/GameDataSO");
            JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(origGameDataSO), GetSO<GameDataSO>());
            SaveGameData();
        }

        #region Save, Load Delete
        public static void LoadData(string filename, ScriptableObject mySO, int slot) {
            string mySlotString = Application.persistentDataPath + "/" + filename + slot + ".dat";
            if (File.Exists(mySlotString)) {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(mySlotString, FileMode.Open);
                JsonUtility.FromJsonOverwrite(SimpleEncryptDecrypt.EncryptDecrypt((string)bf.Deserialize(file)), mySO);
                file.Close();
            }         
        }

        public static void SaveData(string filename, ScriptableObject mySO, int slot) {
            string mySlotString = Application.persistentDataPath + "/" + filename + slot + ".dat";
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(mySlotString);
            var json = SimpleEncryptDecrypt.EncryptDecrypt(JsonUtility.ToJson(mySO));
            bf.Serialize(file, json);
            file.Close();
        }

        public static void DeleteData(string filename, int slot) {
            string mySlotString = Application.persistentDataPath + "/" + filename + slot + ".dat";
            try {
                File.Delete(mySlotString);
                Debug.Log("Deleted: " + mySlotString);
            }
            catch (Exception ex) {
                Debug.LogException(ex);
                Debug.Log("Can't delete file: " + mySlotString);
            }
        }
        #endregion
    }
}