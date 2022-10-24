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
    public class xxxUI_LevelSelecter3 : UI_Menu<xxxUI_LevelSelecter3>
    {
/*        #region INSPECTOR
        [SerializeField] protected Text nameText;
        [SerializeField] protected Image thumbNail;
        
        [SerializeField] protected int levelIndex;

        #endregion

        
        private bool[] levelList = new bool[5];
        [SerializeField] private float playDelay = 0.3f;
        protected LevelSelecter levelSelecter;
        protected LevelSpecs currentLevel;

        protected override void Awake()
        {
            base.Awake();
            levelSelecter = GetComponent<LevelSelecter>();
            
            
            LoadData();
        }

        public void OnEnable()
        {
            UpdateInfo();
        }
        public void UpdateInfo()
        { 
            //2021 09 27 이거 고쳐야해 ---------------------------------------------------
            currentLevel = levelSelecter.GetLevel(MissionObjectList.Instance.playLevelIndex-1);
            
            nameText.text = currentLevel.Name;
            levelIndex = currentLevel.LevelIndex;
            if (MissionObjectList.Instance.FindBySceneName(currentLevel.SceneName).isUnlock)
            { 
                thumbNail.sprite = currentLevel.Image;
            }
            else
            {
                thumbNail.sprite = currentLevel.ImageLocked;

            }

            
            


        }
        public override void OnBtnBackPressed()
        {
            base.OnBtnBackPressed();
            
        }
        public void OnNextPressed()
        {
            levelSelecter.IncrementIndex();
            UpdateInfo();
        }
        public void OnPreviousPressed()
        {
            levelSelecter.DecrementIndex();
            UpdateInfo();
        }

        public void OnPlayPressed()
        {
            if (GameManager.Instance != null && MissionObjectList.Instance.FindBySceneName(currentLevel.SceneName).isUnlock)
            {
                LevelLoader.LoadLevel(currentLevel.SceneName);
                UI_Ingame_R.Open();
                *//*yield return new WaitForSeconds(playDelay);*//*
                UI_Ingame_R.Open();
            }
            else
            {
                Debug.Log("클리어 후 플레이 가능");
            }
        }

        public void LoadData()
        {
            if (DataManager.Instance == null)
            {
                return;
            }
            MissionObjectList.Instance.LoadData();
            DataManager.Instance.Load();
            
            
        }

*/


    }
}
