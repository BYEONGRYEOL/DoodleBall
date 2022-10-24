using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement.Levels;
using Utility;

namespace LevelManagement.Data
{
    public class DataManager : SingletonDontDestroyMonobehavior<DataManager>
    {
        /*private static DataManager instance;
        public static DataManager Instance { get { return instance; } }

        private void OnDestroy()
        {
            if(instance == this)
            {
                instance = null;
            }
        }*/

        public SaveData saveData;
        public JsonSaver jsonSaver;
        public bool Mute { get { return saveData.mute; } set { saveData.mute = value; } }
        public float SFXVolume { get { return saveData.sfxVolume; } set { saveData.sfxVolume = value; } }
        public float MusicVolume { get { return saveData.musicVolume; } set { saveData.musicVolume = value; } }
        public string ID { get { return saveData.id; } set { saveData.id = value; } }
        public string Password { get { return saveData.password; } set { saveData.password = value; } }
        public int TotalStars { get { return saveData.totalStars; } set { saveData.totalStars = value; } }
        public List<MissionObject> MissionObjects { get { return saveData.missionObjects; } set { saveData.missionObjects = value; } }


        
        protected override void Awake()
        {
            base.Awake();
           /* instance = this;
            if (Instance == this)
            {
                DontDestroyOnLoad(gameObject);
            }*/
            saveData = new SaveData();
            jsonSaver = new JsonSaver();
        }

        public void Save()
        {
            Debug.Log("Mute : " + Mute);
            Debug.Log("MusicVolume : " + MusicVolume);
            Debug.Log("SFXVolume : " + SFXVolume);
            Debug.Log("ID : " + ID);
            jsonSaver.Save(saveData);
            
        }

        public void Load()
        {
            Debug.Log("DataManager :: Load");
            jsonSaver.Load(saveData);
        }
    }

}
