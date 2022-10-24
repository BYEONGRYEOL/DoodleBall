using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement.Data;
using LevelManagement;

namespace LevelManagement.Levels
{
    public class MissionObjectList : MonoBehaviour
    {
        private static MissionObjectList instance;
        public static MissionObjectList Instance { get { return instance; } }
        private void OnDestroy()
        {
            if (instance == this)            
                instance = null;
        }

        private List<MissionObject> missionObjects = new List<MissionObject>();
        [SerializeField] public ObjectList objectList;
        [SerializeField] private int totalStars = 0;
        [SerializeField] public int easyLevelCount = 0;
        [SerializeField] public int normalLevelCount = 0;
        [SerializeField] public int hardLevelCount = 0;
        
        private float inkRemainingForStar = 0f;
        private float timeLimitForStar = 0f;
        private bool isCleared = false;
        private bool isUnlock = false;
        public int playLevelIndex;

        public int TotalStars()
        {
            int total = 0;
            for(int i=0; i < objectList.TotalObjects; i++)
            {
                total += objectList.GetLevel(i).StarCollected;
            }
            return total;
        }
        
        
        private void Awake()
        {
            
            if (instance != null)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
            if (Instance == this)
            {
                DontDestroyOnLoad(gameObject);
            }
            LoadData();
        }
        public void LoadData()
        {
            
            if (DataManager.Instance == null || missionObjects == null)
            {
                return;
            }

            DataManager.Instance.Load();

            
            
            if(DataManager.Instance.MissionObjects.Count == 0)
            {
                return;
            }

            totalStars = 0;
            for (int i=0; i < objectList.TotalObjects; i ++)
            {
                //Debug.Log("missionObjects.Count is" +missionObjects.Count);
                //Debug.Log("DataManager.Instance.MissionObjects.Count is"+DataManager.Instance.MissionObjects.Count);
                if (DataManager.Instance.MissionObjects[i].isUnlock)
                {
                    objectList.GetLevel(i).IsUnlock = true;
                }
                if (DataManager.Instance.MissionObjects[i].isCleared)
                {
                    objectList.GetLevel(i).IsCleared = true;
                }
                if (DataManager.Instance.MissionObjects[i].inkStar)
                {
                    objectList.GetLevel(i).InkStar = true;
                }
                if (DataManager.Instance.MissionObjects[i].timeStar)
                {
                    objectList.GetLevel(i).TimeStar = true;
                }
                if (DataManager.Instance.MissionObjects[i].starCollected > 0)
                {
                    
                    objectList.GetLevel(i).StarCollected = DataManager.Instance.MissionObjects[i].StarCollected;
                }
                
            }
            
        }
        private void Start()
        {
            
        }


        public void SaveData()
        {
            if(DataManager.Instance == null)
            {
                return;
            }
            
            DataManager.Instance.TotalStars = totalStars;
            DataManager.Instance.MissionObjects = objectList.objects;

            DataManager.Instance.Save();
        }

        /*public MissionObject FindBySceneName(string sceneName)
        {
            
            foreach(MissionObject missionObject in missionObjects)
            {
                if (missionObject.sceneName == sceneName)
                    return missionObject;
                
            }
            return null;
        }*/

        public MissionObject FindBySceneLevelIndex(int levelindex)
        {
            foreach(MissionObject missionObject in missionObjects)
            {
                if (missionObject.LevelIndex == levelindex)
                    return missionObject;

            }
            return null;
        }

    }

}