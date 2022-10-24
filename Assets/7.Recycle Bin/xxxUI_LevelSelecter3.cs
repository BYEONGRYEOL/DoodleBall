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
    public class UI_LevelSelecter3 : UI_Menu<UI_LevelSelecter3>
    {
        #region INSPECTOR
        [SerializeField] protected Text nameText;
        [SerializeField] protected Image thumbNail;
        
        [SerializeField] protected int levelIndex;

        #endregion

        
        private bool[] levelList = new bool[5];
        //[SerializeField] private float playDelay = 0.3f;
        protected LevelSelecter levelSelecter;
        protected LevelSpecs currentLevel;

        protected override void Awake()
        {
            base.Awake();
            levelSelecter = GetComponent<LevelSelecter>();
            
            
            LoadData();
        }

        /*public void OnEnable()
        {
            UpdateInfo();
        }*/
        public void UpdateInfo()
        { 
            //2021 09 27 이거 고쳐야해 ---------------------------------------------------
            currentLevel = levelSelecter.GetLevel(MissionObjectList.Instance.playLevelIndex-1);
            
            nameText.text = currentLevel.Name;
            levelIndex = currentLevel.LevelIndex;
            /*if (MissionObjectList.Instance.objectList.GetLevel(.isUnlock)
            { 
                thumbNail.sprite = currentLevel.Image;
            }
            else
            {
                thumbNail.sprite = currentLevel.ImageLocked;

            }*/

            
            


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
            
            
           /* if (GameManager.Instance != null && MissionObjectList.Instance.FindBySceneName(currentLevel.SceneName).isUnlock)
            {
                LevelLoader.LoadLevel(currentLevel.SceneName);
                Debug.Log("웨잇세컨즈 직전");
                *//*yield return new WaitForSeconds(playDelay);*//*
                Debug.Log("인게임메뉴 오픈 전");
                UI_Ingame_R.Open();
                Debug.Log("인게임메뉴 오픈 후");
                
            }
            else
            {
                //클리어 이전에 플레이 누른 경우!@!@!
                Debug.Log("클리어 후 플레이 가능");
            }*/
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



    }
}
