using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Levels
{
    public class LevelSelecter : MonoBehaviour
    {
        #region INSPECTOR
        [SerializeField] protected LevelList levelList;
        #endregion
        #region PROTECTED
        protected int currentIndex = 0;
        #endregion

        #region PROPERTIES
        public int CurrentIndex => currentIndex;
        #endregion
        public void ClampIndex()
        {
            if(levelList.TotalLevels == 0)
            {
                Debug.Log("error");
            }

            if(currentIndex >= levelList.TotalLevels)
            {
                currentIndex = 0;
            }

            if(currentIndex < 0)
            {
                currentIndex = levelList.TotalLevels - 1;
            }
        }

        public void SetIndex(int index)
        {
            currentIndex = index;
            ClampIndex();
        }

        public void IncrementIndex()
        {
            SetIndex(currentIndex + 1);
        }
        public void DecrementIndex()
        {
            SetIndex(currentIndex - 1);
        }

        public LevelSpecs GetLevel(int index)
        {
            return levelList.GetLevel(index);
        }

        public LevelSpecs GetCurrentLevel()
        {
            return levelList.GetLevel(currentIndex);
        }
    }
}
