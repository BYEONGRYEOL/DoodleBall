using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LineGame;
using LevelManagement.Levels;
using LevelManagement.Data;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class UI_LevelSelecter1 : UI_Menu<UI_LevelSelecter1>
    {
        #region INSPECTOR
        
        [SerializeField] private Image easyAllCleared;
        [SerializeField] private Image normalAllCleared;
        [SerializeField] private Image hardAllCleared;
        #endregion

        SpriteRenderer spriteRenderer;
        
        //[SerializeField] private float playDelay = 0.3f;
        protected LevelSelecter levelSelecter;
        

        protected override void Awake()
        {
            base.Awake();
            
        }

        public void OpenMenu()
        {
            LoadData();
            Debug.Log("Script :: UI_LevelSelecter1 / Function :: OnEnable");
            UpdateInfo();
        }
        public void UpdateInfo()
        {
            Debug.Log("Script :: UI_LevelSelecter1 / Function :: UpdateInfo");

            if (MissionObjectList.Instance.objectList.GetLevel(MissionObjectList.Instance.easyLevelCount-1).isUnlock)
            {
                easyAllCleared.color = new Color(1, 1, 1, 1);
            }
            else
            {
                easyAllCleared.color = new Color(1, 1, 1, 0);
            }
            if (MissionObjectList.Instance.objectList.GetLevel(MissionObjectList.Instance.easyLevelCount + MissionObjectList.Instance.normalLevelCount -1).isUnlock)
            {
                normalAllCleared.color = new Color(1, 1, 1, 1);
            }
            else
            {
                normalAllCleared.color = new Color(1, 1, 1, 0);
            }
            if (MissionObjectList.Instance.objectList.GetLevel(MissionObjectList.Instance.easyLevelCount + MissionObjectList.Instance.normalLevelCount + MissionObjectList.Instance.hardLevelCount -1).isUnlock)
            {
                hardAllCleared.color = new Color(1, 1, 1, 1);
            }
            else
            {
                hardAllCleared.color = new Color(1, 1, 1, 0);
            }
        }
        public override void OnBtnBackPressed()
        {
            Debug.Log("Script :: UI_LevelSelecter1 / Function :: OnBtnBackPressed");
            base.OnBtnBackPressed();
            LevelLoader.LoadLevel("UI_Animation");
            UI_MainMenu.Open();
        }
        public void OnBtnEasyPressed()
        {
            Debug.Log("Script :: UI_LevelSelecter1 / Function :: OnBtnEasyPressed");

            UI_LevelSelecter2_Easy.Open();
        }
        
        public void OnBtnNormalPressed()
        {
            Debug.Log("Script :: UI_LevelSelecter1 / Function :: OnBtnNormalPressed");

            UI_LevelSelecter2_Normal.Open();
        }
        public void OnBtnHardPressed()
        {
            Debug.Log("Script :: UI_LevelSelecter1 / Function :: OnBtnHardPressed");

            UI_LevelSelecter2_Hard.Open();
        }
        

        public void LoadData()
        {
            Debug.Log("Script :: UI_LevelSelecter1 / Function :: LoadData");

            if (DataManager.Instance == null)
            {
                Debug.LogWarning("Script :: UI_LevelSelecter1 / Function :: OnBtnNormalPressed / DataManager is null");
                return;
            }
            MissionObjectList.Instance.LoadData();
            DataManager.Instance.Load();
        }
    }
}
