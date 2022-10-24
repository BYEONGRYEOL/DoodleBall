using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LineGame;
using UnityEngine.UI;
using TMPro;
using LevelManagement.Levels;
using LevelManagement.Data;

namespace LevelManagement
{
    
    public class UI_Win : UI_Menu<UI_Win>
    {
        private float myTimeScale = 2f;
        private Animator animator;

        [SerializeField] Image star_1_Block;
        [SerializeField] Image star_2_Block;
        [SerializeField] Image star_3_Block;
        [SerializeField] TextMeshProUGUI timeComment;
        [SerializeField] TextMeshProUGUI inkComment;
        [SerializeField] TextMeshProUGUI userName;

        [SerializeField] private string timeComment_1;
        [SerializeField] private string timeComment_2;
        [SerializeField] private string timeComment_3;
        [SerializeField] private string timeComment_4;
        [SerializeField] private string timeComment_5;
        [SerializeField] private string timeComment_6;
        [SerializeField] private string timeComment_7;
        [SerializeField] private string inkComment_1;
        [SerializeField] private string inkComment_2;
        [SerializeField] private string inkComment_3;
        [SerializeField] private string inkComment_4;
        [SerializeField] private string inkComment_5;
        [SerializeField] private string inkComment_6;
        [SerializeField] private string inkComment_7;




        public void OpenMenu()
        {
            SFX.Instance.PlaySFX("Win");
            WinScreenInitialize();

            Time.timeScale = myTimeScale;
            Debug.Log("Script :: UI_Win / Function :: OnEnable");
            Debug.Log("Script :: UI_Win / Function :: OnEnable / timescale is " + Time.timeScale);

            animator = GetComponent<Animator>();
            WinScreen();
        }

        private void WinScreen()
        {

            Debug.Log("UI_Win_WinScreen 실행");
            int star = GameManager.Instance.nowStarCollected;
            float ink = GameManager.Instance.inkLeftRatioNow / GameManager.Instance.inkLeftRatioForStar;
            float time = GameManager.Instance.clearTime / GameManager.Instance.timeLimitForStar;
            DataManager.Instance.Load();
            userName.text = DataManager.Instance.ID;
            Debug.Log("nowStarCollected is" + star);
            animator.SetInteger("Star", star);
            #region selectComment
            if (time >= 3)
            {
                timeComment.text = timeComment_1;
            }
            else if (time >= 2)
            {
                timeComment.text = timeComment_2;
            }
            else if (time >= 1.6)
            {
                timeComment.text = timeComment_3;
            }
            else if (time >= 1.3)
            {
                timeComment.text = timeComment_4;
            }
            else if (time >= 1)
            {
                timeComment.text = timeComment_5;
            }
            else if (time >= 0.8)
            {
                timeComment.text = timeComment_6;
            }
            else
            {
                timeComment.text = timeComment_7;
            }

            if (ink >= 1.5)
            {
                inkComment.text = inkComment_7;
            }
            else if (ink >= 1.2)
            {
                inkComment.text = inkComment_6;
            }
            else if (ink >= 1)
            {
                inkComment.text = inkComment_5;
            }
            else if (ink >= 0.9)
            {
                inkComment.text = inkComment_4;
            }
            else if (ink >= 0.8)
            {
                inkComment.text = inkComment_3;
            }
            else if (ink >= 0.7)
            {
                inkComment.text = inkComment_2;
            }
            else
            {
                inkComment.text = inkComment_1;
            }
            #endregion
            switch (star) 
            {
                case 1:
                    WinScreenFor1Star();
                    return;
                case 2:
                    WinScreenFor2Star();
                    return;
                case 3:
                    WinScreenFor3Star();
                    return;
            }
            Debug.Log("WinScreen 실행");
            
        }
        private void WinScreenFor1Star()
        {
            star_1_Block.gameObject.SetActive(false);
        }
        private void WinScreenFor2Star()
        {
            star_1_Block.gameObject.SetActive(false);
            star_2_Block.gameObject.SetActive(false);

        }
        private void WinScreenFor3Star()
        {
            star_1_Block.gameObject.SetActive(false);
            star_2_Block.gameObject.SetActive(false);
            star_3_Block.gameObject.SetActive(false);

        }
        private void WinScreenInitialize()
        {
            star_1_Block.gameObject.SetActive(true);
            star_2_Block.gameObject.SetActive(true);

            star_3_Block.gameObject.SetActive(true);

        }
        public void OnBtnNextLevelPressed()
        {
            WinScreenInitialize();
            base.OnBtnBackPressed();
            LevelLoader.LoadNextLevel();
            GameManager.Instance.MyResume();
        }

        public void OnBtnPlayAgainPressed()
        {

            base.OnBtnBackPressed();
            
            LevelLoader.ReloadLevel();
            GameManager.Instance.MyResume();
        }
        public void OnBtnMainMenuPressed()
        {
            Time.timeScale = myTimeScale;
            base.OnBtnBackPressed();
            LevelLoader.LoadLevel("UI_Animation");
            UI_MainMenu.Open();
        }
    }
}