using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineGame;
using UnityEngine.SceneManagement;
using TMPro;
using LevelManagement.Levels;
namespace LevelManagement
{
    public class UI_Pause : UI_Menu<UI_Pause>
    {

        [SerializeField] TextMeshProUGUI txt_Label;
        

        public void OpenMenu()
        {
            
            if (MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().SceneName == null)
            {
                txt_Label.text = "";
            }
            txt_Label.text = MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().SceneName; 
        }

        public void OnBtnResumePressed()
        {
            GameManager.Instance.MyResume();
            base.OnBtnBackPressed();
            
        }
        public void OnBtnMainMenuPressed()
        {
            base.OnBtnBackPressed();
            LevelLoader.LoadLevel("UI_Animation");
            UI_MainMenu.Open();
        }
        public void OnBtnQuitGamePressed()
        {
            Application.Quit();
        }

        
    }
}