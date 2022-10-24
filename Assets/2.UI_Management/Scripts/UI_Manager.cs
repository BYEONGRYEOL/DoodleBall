using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace LevelManagement
{
    
    public class UI_Manager : MonoBehaviour
    {
        
        [SerializeField] private UI_MainMenu mainMenuPrefab;
        [SerializeField] private UI_Option optionPrefab;
        [SerializeField] private UI_Score scorePrefab;
        [SerializeField] private UI_Ingame_R ingamePrefab_R;
        
        [SerializeField] private UI_Pause pausePrefab;
        [SerializeField] private UI_Win winPrefab;
        [SerializeField] private UI_LevelSelecter1 levelSelecter1Prefab;
        [SerializeField] private UI_LevelSelecter2_Easy levelSelecter2EasyPrefab;
        [SerializeField] private UI_LevelSelecter2_Normal levelSelecter2NormalPrefab;
        [SerializeField] private UI_LevelSelecter2_Hard levelSelecter2HardPrefab;
        [SerializeField] private UI_Login loginPrefab;


        [SerializeField] private Transform myMenuParent;

        #region ΩÃ±€≈Ê 
        private static UI_Manager instance;
        public static UI_Manager Instance
        {
            get
            {
                return instance;
            }
            /*set //¡÷ºÆ√≥∏Æ«‘¿∏∑ŒΩ· read only∞° µ«æÓøÎ
            {
                instance = value;
            }*/
        }
        private void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
        #endregion ΩÃ±€≈Ê
        private Stack<UI_Menu> myMenuStack = new Stack<UI_Menu>();
        private void Start()
        {
            
        }
        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                InitializeMenus();
                DontDestroyOnLoad(gameObject);
            }
        }

        private void InitializeMenus()
        {
            if(myMenuParent == null)
            {
                GameObject menuParentObject = new GameObject("Menus");
                myMenuParent = menuParentObject.transform;
            }
            DontDestroyOnLoad(myMenuParent.gameObject);
            
            System.Type myType = this.GetType();

            BindingFlags myFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
            FieldInfo[] fields = myType.GetFields(myFlags);


            foreach(FieldInfo field in fields)
            {
                UI_Menu prefab = field.GetValue(this) as UI_Menu;

                if(prefab != null)
                {
                    UI_Menu menuInstance = Instantiate(prefab, myMenuParent);
                    
                    if(prefab != loginPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenMenu(menuInstance);
                    }
                }
            }
        }
       
        public void OpenMenu(UI_Menu menuInstance)
        {
            if(menuInstance == null)
            {
                Debug.LogWarning("Script MenuManager Function OpenMenu Error : invalid menu");
                return;
            }
            if(myMenuStack.Count > 0)
            {
                foreach(UI_Menu menu in myMenuStack)
                {
                    menu.gameObject.SetActive(false);
                }
            }
            menuInstance.gameObject.SetActive(true);
            myMenuStack.Push(menuInstance);


            string a = menuInstance.name;
            string menuName = a.Remove(a.IndexOf("("));
            Debug.Log(menuName);
            if (menuName == "UI_Login")
            {
                UI_Login.Instance.OpenMenu();
            }
            else if(menuName == "UI_Menu")
            {
                UI_MainMenu.Instance.OpenMenu();
            }
            else if(menuName == "UI_Option")
            {
                UI_Option.Instance.OpenMenu();
            }
            else if (menuName == "UI_Pause")
            {
                UI_Pause.Instance.OpenMenu();
            }
            else if (menuName == "UI_Score")
            {
                UI_Score.Instance.OpenMenu();
            }
            else if (menuName == "UI_Win")
            {
                UI_Win.Instance.OpenMenu();
            }
            else if (menuName == "UI_Ingame_R")
            {
                UI_Ingame_R.Instance.OpenMenu();
            }
            else if (menuName == "UI_LevelSelecter1")
            {
                UI_LevelSelecter1.Instance.OpenMenu();
            }
            else if (menuName == "UI_LevelSelecter2_Easy")
            {
                UI_LevelSelecter2_Easy.Instance.OpenMenu();
            }
            else if (menuName == "UI_LevelSelecter2_Normal")
            {
                UI_LevelSelecter2_Normal.Instance.OpenMenu();
            }
            else if (menuName == "UI_LevelSelecter2_Hard")
            {
                UI_LevelSelecter2_Hard.Instance.OpenMenu();
            }
            
            /*a = "";
            menuName = "";*/
        }

        public void CloseMenu()
        {
            if(myMenuStack.Count == 0)
            {
                Debug.LogWarning("Scirpt MenuManager Function CloseMenu ERROR : there's no menu to close in stack");
                return;
            }

            UI_Menu topMenu = myMenuStack.Pop();
            topMenu.gameObject.SetActive(false);

            if(myMenuStack.Count > 0)
            {
                UI_Menu nextMenu = myMenuStack.Peek();
                nextMenu.gameObject.SetActive(true);
            }
        }
    }

}
