using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineGame;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;
using LevelManagement.Levels;

namespace LevelManagement
{
    
    public class UI_Ingame_R : UI_Menu<UI_Ingame_R>
    {
        #region SerializeField
        [SerializeField] public Image lineToggleCheck;
        [SerializeField] public Image lineWithGravityToggleCheck;
        [SerializeField] public Image lineUpToggleCheck;
        [SerializeField] public Image lineWithAccelToggleCheck;
        [SerializeField] public Image zoomToggleCheck;

        [SerializeField] public TextMeshProUGUI challengeInk;
        [SerializeField] public TextMeshProUGUI challengeTime;

        [SerializeField] public TextMeshProUGUI lineAmount;
        [SerializeField] public TextMeshProUGUI lineWithGravityAmount;
        [SerializeField] public TextMeshProUGUI lineUpAmount;
        [SerializeField] public TextMeshProUGUI lineWithAccelAmount;

        [SerializeField] public Toggle zoomToggle;

        [SerializeField] public Toggle lineWithGravityToggle;
        [SerializeField] public Slider lineWithGravityInkSlider;
        [SerializeField] public Toggle lineToggle;
        [SerializeField] public Slider lineInkSlider;
        [SerializeField] public Toggle lineUpToggle;
        [SerializeField] public Slider lineUpInkSlider;
        [SerializeField] public Toggle lineWithAccelToggle;
        [SerializeField] public Slider lineWithAccelInkSlider;
        [SerializeField] public TextMeshProUGUI usedInkNow;
        #endregion

        private Animator animator;
        private GameObject[] lines;
        private GameObject player;

        private string challengeInkString;
        private string challengeTimeString;
        private bool toggleDisable = false;
        public float delay = 0.4f;
        public float myTimeScale = 2f;
        protected override void Awake()
        {
            base.Awake();
            
        }
        public void OpenMenu()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: OnEnable");
            SceneInitialized();
            animator = GetComponent<Animator>();
            
            
        }
        public void OnCheckToDoListPressed()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: OnCheckToDoListPressed");
            Debug.Log("Script :: UI_Ingame_R / Function :: OnCheckToDoListPressed / animator parameter 'Check' is" + animator.GetBool("Check"));
            if (!animator.GetBool("Check"))
            {
                animator.SetBool("Check", true);
            }
            else
            {
                animator.SetBool("Check", false);
            }
        }
        public void OnBtnPausePressed()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: OnBtnPausePressed");
            Time.timeScale = 0;
            UI_Pause.Open();

        }

        public void OnDrawLineWithGravityToggleChanged()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineWithGravityToggleChanged");
            
            if (toggleDisable)
            {
                Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineWithGravityToggleChanged / Parameter :: toggleDisable is true");
                return;
            }
            MultitouchOff();

            if (DrawLineWithGravity.Instance == null)
                Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineWithGravityToggleChanged Error :: drawLineWithGravity is null");
            DrawLineWithGravity.Instance.ToggleEnable();
        }
        public void OnDrawLineToggleChanged()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineToggleChanged");
            if (toggleDisable)
            {
                Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineToggleChanged / Parameter :: toggleDisable is true");
                return;
            }
            MultitouchOff();

            if (DrawLine.Instance == null)
                Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineToggleChanged Error :: drawLineWithGravity is null");
            DrawLine.Instance.ToggleEnable();
        }
        public void OnDrawLineUpToggleChanged()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineUpToggleChanged");
            if (toggleDisable)
            {
                Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineUpToggleChanged / Parameter :: toggleDisable is true");
                return;
            }
            MultitouchOff();

            if (DrawLineUp.Instance == null)
                Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineUpToggleChanged Error :: drawLineWithGravity is null");
            DrawLineUp.Instance.ToggleEnable();
        }
        public void OnDrawLineWithAccelToggleChanged()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineWithAccelToggleChanged");
            if (toggleDisable)
            {
                Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineWithAccelToggleChanged / Parameter :: toggleDisable is true");
                return;
            }
            MultitouchOff();

            if (DrawLineWithAccel.Instance == null)
                Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineWithAccelToggleChanged Error :: drawLineWithGravity is null");
            DrawLineWithAccel.Instance.ToggleEnable();
        }
        public void OnZoomToggleChanged()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: OnDrawLineWithAccelToggleChanged");
            if (zoomToggle.isOn)
            {
                zoomToggleCheck.gameObject.SetActive(true);
                MultitouchOn();
            }
            else
            {
                zoomToggleCheck.gameObject.SetActive(false);
                MultitouchOff();
            }
        }

        public void OnEraserClick()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: OnEraserClick");
            if (toggleDisable)
            {
                Debug.Log("Script :: UI_Ingame_R / Function :: OnEraserClick / Parameter :: toggleDisable is true");
                return;

            }
            lines = GameObject.FindGameObjectsWithTag("myPen");
            for (int i = 0; i < lines.Length; i++)
            {
                Debug.Log("Script :: UI_Ingame_R / Function :: OnEraserClick / Destroy(lines[i]) Verge");
                Destroy(lines[i]);
            }
            DrawLineWithGravity.Instance.EraseLine();
            DrawLine.Instance.EraseLine();
            DrawLineUp.Instance.EraseLine();
            DrawLineWithAccel.Instance.EraseLine();
            SliderUpdate();
        }


        public void OnStartBtnClick()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: OnStartBtnClick");
            Time.timeScale = myTimeScale;
            if (toggleDisable)
            {
                Debug.Log("Script :: UI_Ingame_R / Function :: OnStartBtnClick / Parameter :: toggleDisable is true");
                return;
            }
            /*DrawLineWithGravity.Instance.activeToggle.isOn = false;
            DrawLine.Instance.activeToggle.isOn = false;
            DrawLineUp.Instance.activeToggle.isOn = false;
            DrawLineWithAccel.Instance.activeToggle.isOn = false;
            toggleDisable = true;*/
            GameManager.Instance.Start_Timer();
            
            lines = GameObject.FindGameObjectsWithTag("myPen");
            Debug.Log("Script :: UI_Ingame_R / Function :: OnStartBtnClick / GameObject :: player is null ?" + player == null);
            Debug.Log("Script :: UI_Ingame_R / Function :: OnStartBtnClick / GameObject[] :: lines is null ?" + lines == null);
            
            for (int i = 0; i < lines.Length; i++)
            {
                //isKinematic is false for LineWithGravity Only
                if (lines[i].name == "LineWithGravityPrefab(Clone)")
                {
                    
                    lines[i].GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }
            
            //Start btn must works just once
            if (player == null)
            {
                Debug.Log("player ¿Ãµø");
                player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Rigidbody2D>().isKinematic = false;
                
                //player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f, 0), ForceMode2D.Impulse);
            }
            else
            {
                Debug.Log("Script :: UI_Ingame_R / Function :: OnStartBtnClick / GameObject :: player is not null");

            }
            /*IEnumerator instantCoroutine = OnStartBtnClick_Coroutine();
            StartCoroutine(instantCoroutine);*/
        }
        /*private IEnumerator OnStartBtnClick_Coroutine()
        {
            yield return new WaitForSeconds(delay);
        }*/

        public void SceneInitialized()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: SceneInitialized");

            // When initialized, btns must work normally :: Parameter initializing
            toggleDisable = false;
            player = null;
            lines = null;
            Time.timeScale = myTimeScale;

            // Drawing initializing
            if(DrawLineWithGravity.Instance == null || DrawLine.Instance == null)
            {
                return;
            }
            DrawLineWithGravity.Instance.EraseLine();
            DrawLine.Instance.EraseLine();
            DrawLineUp.Instance.EraseLine();
            DrawLineWithAccel.Instance.EraseLine();
            DrawLine.Instance.SceneInitialized();
            DrawLineWithGravity.Instance.SceneInitialized();
            DrawLineUp.Instance.SceneInitialized();
            DrawLineWithAccel.Instance.SceneInitialized();
            //information UI Update
            SliderUpdate();
            challengeInkString = (MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().InkLeftRatioForStar * 100).ToString() + "%";
            challengeTimeString =  MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().TimeLimitForStar.ToString();
            ChallengeUpdate();
            Debug.Log(challengeInkString);
        }


        public void OnBtnRestartPressed()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: OnBtnRestartPressed");
            LevelLoader.ReloadLevel();
            SceneInitialized();
        }

        public void SliderUpdate()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: SliderUpdate");
            // Avoid to devide into zero
            if (DrawLine.Instance.maxInk_line == 0)
            {
                lineInkSlider.value = 0;
            }
            else
            {
                lineInkSlider.value = 1 - (DrawLine.Instance.nowInk_line / DrawLine.Instance.maxInk_line);

            }
            // Avoid to devide into zero
            if (DrawLineWithGravity.Instance.maxInk_line == 0)
            {
                lineWithGravityInkSlider.value = 0;
            }
            else
            {
                lineWithGravityInkSlider.value = 1 - (DrawLineWithGravity.Instance.nowInk_line / DrawLineWithGravity.Instance.maxInk_line);
            }
            // Avoid to devide into zero
            if (DrawLineUp.Instance.maxInk_line == 0)
            {
                lineUpInkSlider.value = 0;
            }
            else
            {
                lineUpInkSlider.value = 1 - (DrawLineUp.Instance.nowInk_line / DrawLineUp.Instance.maxInk_line);

            }// Avoid to devide into zero
            if (DrawLine.Instance.maxInk_line == 0)
            {
                lineWithAccelInkSlider.value = 0;
            }
            else
            {
                lineWithAccelInkSlider.value = 1 - (DrawLineWithAccel.Instance.nowInk_line / DrawLineWithAccel.Instance.maxInk_line);

            }
            lineAmount.text = Math.Truncate(lineInkSlider.value * 100).ToString() + "%";
            lineWithGravityAmount.text = Math.Truncate(lineWithGravityInkSlider.value * 100).ToString() + "%";
            lineUpAmount.text = Math.Truncate(lineUpInkSlider.value * 100).ToString() + "%";
            lineWithAccelAmount.text = Math.Truncate(lineWithAccelInkSlider.value * 100).ToString() + "%";

            Debug.Log("lineInkSlider.value is " + lineInkSlider.value);
            Debug.Log("lineWithGravityInkSlider.value is " + lineWithGravityInkSlider.value);

            usedInkNow.text ="ink used"+Math.Truncate((DrawLine.Instance.nowInk_line + DrawLineWithGravity.Instance.nowInk_line + 
                DrawLineUp.Instance.nowInk_line + DrawLineWithAccel.Instance.nowInk_line)
                / (DrawLine.Instance.maxInk_line + DrawLineWithGravity.Instance.maxInk_line + DrawLineUp.Instance.maxInk_line
                + DrawLineWithAccel.Instance.maxInk_line) * 100).ToString() + "%";
        }
        public void ChallengeUpdate()
        {
            Debug.Log("Script :: UI_Ingame_R / Function :: ChallengeUpdate");
            challengeInk.text = challengeInkString;
            challengeTime.text = challengeTimeString;
        }

        public void MultitouchOn()
        {
            Input.multiTouchEnabled = false;
        }
        public void MultitouchOff()
        {
            Input.multiTouchEnabled = true;
        }
    }

}
