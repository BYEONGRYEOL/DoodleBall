using System.Collections;
using System.Collections.Generic;
using System;
using LevelManagement.Levels;
namespace LevelManagement.Data
{
    
    public class SaveData
    {
        
        public string id;
        public string password;
        private readonly string defaultID = "ID";
        private readonly string defaultPassword = "Password";
        public List<MissionObject> missionObjects;
        public int totalStars;

        public bool mute;
        public float sfxVolume;
        public float musicVolume;

        

        public SaveData()
        {
            id = defaultID;
            password = defaultPassword;
            mute = false;
            sfxVolume = 0f;
            musicVolume = 0f;
            missionObjects = new List<MissionObject>();
            totalStars = default;
            
        }
    }
}