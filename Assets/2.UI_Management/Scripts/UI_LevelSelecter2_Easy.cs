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
    public class UI_LevelSelecter2_Easy : UI_Menu<UI_LevelSelecter2_Easy>
    {
        #region INSPECTOR

        [SerializeField] protected Image thumbNail_1;
        [SerializeField] protected Image thumbNail_2;
        [SerializeField] protected Image thumbNail_3;
        [SerializeField] protected Image thumbNail_4;
        [SerializeField] protected Image thumbNail_5;
        [SerializeField] protected Image thumbNail_6;
        [SerializeField] protected Image thumbNail_7;
        [SerializeField] protected Image thumbNail_8;
        [SerializeField] protected Image thumbNail_9;
        [SerializeField] protected Image thumbNail_10;
        [SerializeField] protected Image star_1_1;
        [SerializeField] protected Image star_1_2;
        [SerializeField] protected Image star_1_3;
        [SerializeField] protected Image star_2_1;
        [SerializeField] protected Image star_2_2;
        [SerializeField] protected Image star_2_3;
        [SerializeField] protected Image star_3_1;
        [SerializeField] protected Image star_3_2;
        [SerializeField] protected Image star_3_3;
        [SerializeField] protected Image star_4_1;
        [SerializeField] protected Image star_4_2;
        [SerializeField] protected Image star_4_3;
        [SerializeField] protected Image star_5_1;
        [SerializeField] protected Image star_5_2;
        [SerializeField] protected Image star_5_3;
        [SerializeField] protected Image star_6_1;
        [SerializeField] protected Image star_6_2;
        [SerializeField] protected Image star_6_3;
        [SerializeField] protected Image star_7_1;
        [SerializeField] protected Image star_7_2;
        [SerializeField] protected Image star_7_3;
        [SerializeField] protected Image star_8_1;
        [SerializeField] protected Image star_8_2;
        [SerializeField] protected Image star_8_3;
        [SerializeField] protected Image star_9_1;
        [SerializeField] protected Image star_9_2;
        [SerializeField] protected Image star_9_3;
        [SerializeField] protected Image star_10_1;
        [SerializeField] protected Image star_10_2;
        [SerializeField] protected Image star_10_3;



        #endregion
        [SerializeField] private float playDelay = 0.3f;

        private int page = 0;
        private int initialPage = 0;
        private int playLevelIndex = 0;
        
        private List<Image> thumbNailList;
        private List<List<Image>> starList;
        protected LevelSelecter levelSelecter;
        protected List<LevelSpecs> currentLevelList;
        SpriteRenderer spriteRenderer;
        protected override void Awake()
        {
            base.Awake();
            
        }

        public void OpenMenu()
        {
            Debug.Log("Script :: UI_LevelSelecter2_Easy // Function :: Awake");

            levelSelecter = GetComponent<LevelSelecter>();
            currentLevelList = new List<LevelSpecs>();
            thumbNailList = new List<Image>();
            starList = new List<List<Image>>();

            for (int i = 0; i < 10; i++)
            {
                starList.Add(new List<Image>());
            }
            #region ADDLIST
            starList[0].Add(star_1_1);
            starList[0].Add(star_1_2);
            starList[0].Add(star_1_3);
            starList[1].Add(star_2_1);
            starList[1].Add(star_2_2);
            starList[1].Add(star_2_3);
            starList[2].Add(star_3_1);
            starList[2].Add(star_3_2);
            starList[2].Add(star_3_3);
            starList[3].Add(star_4_1);
            starList[3].Add(star_4_2);
            starList[3].Add(star_4_3);
            starList[4].Add(star_5_1);
            starList[4].Add(star_5_2);
            starList[4].Add(star_5_3);
            starList[5].Add(star_6_1);
            starList[5].Add(star_6_2);
            starList[5].Add(star_6_3);
            starList[6].Add(star_7_1);
            starList[6].Add(star_7_2);
            starList[6].Add(star_7_3);
            starList[7].Add(star_8_1);
            starList[7].Add(star_8_2);
            starList[7].Add(star_8_3);
            starList[8].Add(star_9_1);
            starList[8].Add(star_9_2);
            starList[8].Add(star_9_3);
            starList[9].Add(star_10_1);
            starList[9].Add(star_10_2);
            starList[9].Add(star_10_3);
            thumbNailList.Add(thumbNail_1);
            thumbNailList.Add(thumbNail_2);
            thumbNailList.Add(thumbNail_3);
            thumbNailList.Add(thumbNail_4);
            thumbNailList.Add(thumbNail_5);
            thumbNailList.Add(thumbNail_6);
            thumbNailList.Add(thumbNail_7);
            thumbNailList.Add(thumbNail_8);
            thumbNailList.Add(thumbNail_9);
            thumbNailList.Add(thumbNail_10);
            #endregion
            LoadData();
            page = 0;
            initialPage = page;
            UpdateInfo();
        }
        public void UpdateInfo()
        {
            
            Debug.Log("Script :: UI_LevelSelecter2_Easy // Function :: UpdateInfo");
            
            currentLevelList.Clear();
            
            
            for (int i = 0; i < 10; i++)
            {
                // currentLevelList의 i번째 항목이 i+1 Stage이다.
                currentLevelList.Add(levelSelecter.GetLevel(i + (page * 10)));
                //debuging null check
                Debug.Log("Missionobjectlist.instance is null? " + MissionObjectList.Instance);
                Debug.Log("currentLevelList is null? " + currentLevelList);
                Debug.Log("currentLevelList[1] is null? " + currentLevelList[0]);
                Debug.Log("currentLevelList[1].SceneName is null? " + currentLevelList[0].SceneName);
                Debug.Log("starList[0][0] is null? " + starList[0][0]);
                //별 개수 나오게하고싶은데 ㅠㅠ
                if (MissionObjectList.Instance.objectList.GetLevel(i).StarCollected == 1)
                {
                    Debug.Log("i is " + i);
                    // has 1 star for stage i
                    starList[i][0].color = new Color(1, 1, 1, 1);
                    starList[i][1].color = new Color(1, 1, 1, 0);
                    starList[i][2].color = new Color(1, 1, 1, 0);


                }
                else if (MissionObjectList.Instance.objectList.GetLevel(i).StarCollected == 2)
                {
                    Debug.Log("i is " + i);
                    // has 2 stars for stage i
                    starList[i][0].color = new Color(1, 1, 1, 1);
                    starList[i][1].color = new Color(1, 1, 1, 1);
                    starList[i][2].color = new Color(1, 1, 1, 0);



                }
                else if (MissionObjectList.Instance.objectList.GetLevel(i).StarCollected == 3)
                {
                    Debug.Log("i is " + i);
                    // has 3 stars for stage i
                    starList[i][0].color = new Color(1, 1, 1, 1);
                    starList[i][1].color = new Color(1, 1, 1, 1);
                    starList[i][2].color = new Color(1, 1, 1, 1);
                }
                else
                {
                    Debug.Log("i is " + i);
                    starList[i][0].color = new Color(1, 1, 1, 0);
                    starList[i][1].color = new Color(1, 1, 1, 0);
                    starList[i][2].color = new Color(1, 1, 1, 0);
                }
                if (currentLevelList[i].LevelIndex <= MissionObjectList.Instance.easyLevelCount-1)
                {
                    if (MissionObjectList.Instance.objectList.GetLevel(i).isUnlock)
                    {
                        // unlocked stage thumbnail

                        thumbNailList[i].sprite = currentLevelList[i].Image;
                    }
                    else
                    {
                        // locked stage thumbnail

                        thumbNailList[i].sprite = currentLevelList[i].ImageLocked;
                    } 
                }
                else
                {
                    thumbNailList[i].sprite = currentLevelList[i].ImageLocked;

                }
            }
        }
        public void OnBtnPlayPressed()
        {
            Debug.Log("int :: page is" + page);
            Debug.Log("MissionObjectList.Instance.easyLevelCount is" + MissionObjectList.Instance.easyLevelCount);
            Debug.Log("Script :: UI_LevelSelecter2_Easy // Function :: OnBtnPlayPressed");
            StartCoroutine(OnBtnPlayPressedCoroutine());
        }
        IEnumerator OnBtnPlayPressedCoroutine()
        {
            //if click unlocked stage
            if (GameManager.Instance != null && MissionObjectList.Instance.objectList.GetLevel(playLevelIndex -1).IsUnlock)
            {
                //stage begins
                LevelLoader.LoadLevel(currentLevelList[playLevelIndex - 1].SceneName);

                yield return new WaitForSeconds(playDelay);
                UI_Ingame_R.Open();
            }
            else
            {
                //if click locked stage
                Debug.Log("클리어 후 플레이 가능");
            }
        }
        public override void OnBtnBackPressed()
        {
            Debug.Log("Script :: UI_LevelSelecter2_Easy // Function :: OnBtnBackPressed");
            base.OnBtnBackPressed();
            UI_LevelSelecter1.Open();
        }
        public void OnBtnNextPressed()
        {
            Debug.Log("Script :: UI_LevelSelecter2_Easy // Function :: OnBtnNextPressed");
            //no more easy stages there!
            if (page + 1 > (MissionObjectList.Instance.easyLevelCount - 1) / 10)
            {
                return;
            }
            page += 1;
            UpdateInfo();
        }
        public void OnBtnPreviousPressed()
        {
            Debug.Log("Script :: UI_LevelSelecter2_Easy // Function :: OnBtnPreviousPressed");
            //no more easy stages there!
            if (page - 1 < initialPage)
                return;
            page -= 1;
            UpdateInfo();
        }

        public void LoadData()
        {
            Debug.Log("Script :: UI_LevelSelecter2_Easy // Function :: LoadData");
            if (DataManager.Instance == null)
            {
                Debug.LogWarning("Script :: UI_LevelSelecter2_Easy // Function :: LoadData // datamanager is null");

                return;
            }
            DataManager.Instance.Load();
            MissionObjectList.Instance.LoadData();
            
        }

        public void OnBtnThumbNail_1Click()
        {
            //실제 개수로 count 
            if(MissionObjectList.Instance.easyLevelCount >= (page * 10) + 1)
            {
                playLevelIndex =  1;
                OnBtnPlayPressed();
            }
                
        }
        public void OnBtnThumbNail_2Click()
        {
            if (MissionObjectList.Instance.easyLevelCount >= (page * 10) + 2)
            {
                playLevelIndex =  2;
                OnBtnPlayPressed();
            }
                
        }
        public void OnBtnThumbNail_3Click()
        {
            if (MissionObjectList.Instance.easyLevelCount >= (page * 10) + 3)
            {
                playLevelIndex =  3;
                OnBtnPlayPressed();
            }
                
        }
        public void OnBtnThumbNail_4Click()
        {
            if (MissionObjectList.Instance.easyLevelCount >= (page * 10) + 4)
            {
                playLevelIndex =  4;
                OnBtnPlayPressed();
            }
                
        }
        public void OnBtnThumbNail_5Click()
        {
            if (MissionObjectList.Instance.easyLevelCount >= (page * 10) + 5)
            {
                playLevelIndex =  5;
                OnBtnPlayPressed();
            }

        }
        public void OnBtnThumbNail_6Click()
        {
            if (MissionObjectList.Instance.easyLevelCount >= (page * 10) + 6)
            {
                playLevelIndex =  6;
                OnBtnPlayPressed();
            }
        }

        public void OnBtnThumbNail_7Click()
        {
            if (MissionObjectList.Instance.easyLevelCount >= (page * 10) + 7)
            {
                playLevelIndex = 7;
                OnBtnPlayPressed();
            }

        }
        public void OnBtnThumbNail_8Click()
        {
            if (MissionObjectList.Instance.easyLevelCount >= (page * 10) + 8)
            {
                playLevelIndex =  8;
                OnBtnPlayPressed();
            }
        }

        public void OnBtnThumbNail_9Click()
        {
            if (MissionObjectList.Instance.easyLevelCount >= (page * 10) + 9)
            {
                playLevelIndex =  9;
                OnBtnPlayPressed();
            }
        }

        public void OnBtnThumbNail_10Click()
        {
            if (MissionObjectList.Instance.easyLevelCount >= (page * 10) + 10)
            {
                playLevelIndex =  10;
                OnBtnPlayPressed();
            }
        }

    }
}