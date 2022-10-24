using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineGame;
using LevelManagement.Levels;
using LevelManagement.Data;
namespace LevelManagement
{
    public class UI_MainMenu : UI_Menu<UI_MainMenu>
    {
        [SerializeField] TransitionFader transitionPrefab;
        [SerializeField] GameObject ball;
        private float musicVolume;
        public void OpenMenu()
        {
            Debug.Log("WOW");
            Debug.Log(MissionObjectList.Instance);
            MissionObjectList.Instance.LoadData();
            DataManager.Instance.Load();
            musicVolume = DataManager.Instance.MusicVolume;
            BGM.Instance.Volume(musicVolume);
            MissionObjectList.Instance.LoadData();
        }
        
        public void OnBtnPlayPressed()
        {
            Debug.Log("Script :: UI_MainMenu / Function :: OnPlayPressed");
            LevelLoader.LoadMainMenu();
            UI_LevelSelecter1.Open();
           


        }
        public void OnBtnOptionPressed()
        {
            Debug.Log("Script :: UI_MainMenu / Function :: OnOptionPressed");
            LevelLoader.LoadMainMenu();
            UI_Option.Open();
        }

        public void OnBtnScorePressed()
        {
            Debug.Log("Script :: UI_MainMenu / Function :: OnScorePressed");
            LevelLoader.LoadMainMenu();
            UI_Score.Open();
        }

        //Quit.
        public override void OnBtnBackPressed()
        {
            Debug.Log("Script :: UI_MainMenu / Function :: OnBackPressed");
            Application.Quit();
        }

        
    }
}