using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineGame;
using TMPro;
using LevelManagement.Data;
using LevelManagement.Levels;

namespace LevelManagement
{
    public class UI_Score : UI_Menu<UI_Score>
    {
        [SerializeField] private TextMeshProUGUI starComment;
        [SerializeField] private TextMeshProUGUI levelComment;

        public void OpenMenu()
        {
            Initialize();
        }
        private void Initialize()
        {
            MissionObjectList.Instance.LoadData();
            
            starComment.text = MissionObjectList.Instance.TotalStars().ToString() + " / " + DataManager.Instance.MissionObjects.Count * 3;

        }
        public override void OnBtnBackPressed()
        {

            base.OnBtnBackPressed();
            LevelLoader.LoadLevel("UI_Animation");

        }
    }
}