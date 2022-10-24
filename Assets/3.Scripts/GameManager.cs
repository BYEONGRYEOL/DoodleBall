using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelManagement;
using LevelManagement.Data;
using LevelManagement.Levels;
using Utility;
namespace LineGame
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        
        /*private static GameManager instance;
        public static GameManager Instance{get{return instance;}}
        private void OnDestroy(){if (instance == this){instance = null;}}
        */
        private GameObject myPlayer;
        private Player_Objective myObjective;
        public float inkLeftRatioNow;
        public float inkLeftRatioForStar;
        public float timeLimitForStar;
        public int nowStarCollected;
        public float clearTime;
        public float timeScaleNow;
        public float timeStartBtnPressed;
        public float timeNow;
        private bool stopTimer = false;
        private bool endTimer = false;
        private bool isGameOver;
        
        public bool IsGameOver { get { return isGameOver; } }
        
        protected override void Awake()
        {
            base.Awake();
            /*if (instance != null)
            { 
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                
            }*/
            myPlayer = GameObject.FindGameObjectWithTag("Player");
            myObjective = FindObjectOfType<Player_Objective>();

        }

        public void EndLevel()
        {
            if (myPlayer != null && Time.timeScale != 0 && !isGameOver)
            {
                //TimeSclae 저장
                timeScaleNow = Time.timeScale;
                Debug.Log("Script :: GameManager // Function :: EndLevel // Parameter :: timeScaleNow is" + timeScaleNow);
                Time.timeScale = 0;
                //남은 잉크 받아오기
                inkLeftRatioNow = 1 - ((DrawLine.Instance.nowInk_line + DrawLineWithGravity.Instance.nowInk_line) /
                    (DrawLine.Instance.maxInk_line + DrawLineWithGravity.Instance.maxInk_line));
            }

            if (!isGameOver)
            {
                nowStarCollected = 0;
                End_Timer();
                isGameOver = true;
                LevelEnded();
                Debug.Log("???????????");
                Time.timeScale = 2;
                Debug.Log("Script :: GameManager // Function :: EndLevel // Parameter :: timeScaleNow is" + timeScaleNow);
                UI_Win.Open();
            }
        }
        private void Start()
        {
            
        }
        
        // Update is called once per frame
        private void Update()
        {
            
            if (myObjective != null && myObjective.IsComplete)
            {
                EndLevel();
            }
            if (endTimer)
                return;
            Timer();
        }
        
        public void Timer()
        {
            timeNow = Time.time - timeStartBtnPressed;
            if (stopTimer)
            {
                clearTime = timeNow / 2;
                Debug.Log(clearTime);
                endTimer = true;
            }

        }
        public void Start_Timer()
        {
            stopTimer = false;
            timeStartBtnPressed = Time.time;
            Debug.Log("timeStartBtnPressed is" + timeStartBtnPressed);
        }
        private void End_Timer()
        {
            stopTimer = true;
        }
        public void MyPause()
        {
            timeScaleNow = Time.timeScale;
            Time.timeScale = 0;
        }
        public void MyResume()
        {
            Time.timeScale = timeScaleNow;
            Debug.Log("timeScale is" + Time.timeScale);
            UI_Ingame_R.Instance.SceneInitialized();
        }
        private void LevelEnded()
        {
            int a = MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().LevelIndex + 1;
            MissionObjectList.Instance.objectList.GetLevel(a).IsUnlock = true;
            
            //Debug.Log(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name.ToString());
            //MissionObjectList.Instance.FindBySceneName(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name.ToString()).isCleared = true;

            //MissionObjectList.Instance.FindBySceneName(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name).isUnlock = true;
            
            inkLeftRatioForStar = MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().InkLeftRatioForStar;
            timeLimitForStar = MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().TimeLimitForStar;
            if (MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().IsCleared == false)
            {
                Debug.Log("첫 클리어일때만 실행");
                MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().StarCollected += 1;
                MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().isCleared = true;
            }
            nowStarCollected += 1;

            if (inkLeftRatioNow >= inkLeftRatioForStar)
            {
                if(MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().InkStar == false)
                {
                    Debug.Log("첫 클리어일때만 실행");

                    MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().StarCollected += 1;
                    MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().InkStar = true;
                }
                Debug.Log("GameManager // ink challenge");
                nowStarCollected += 1;
            }

            if (clearTime <= timeLimitForStar)
            {
                if(MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().TimeStar == false)
                {
                    Debug.Log("첫 클리어일때만 실행");
                    MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().StarCollected += 1;
                    MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().TimeStar = true;
                }
                Debug.Log("GameManager // time challenge");
                nowStarCollected += 1;
            }
            MissionObjectList.Instance.SaveData();
            DataManager.Instance.Save();
        }
        
    }
}