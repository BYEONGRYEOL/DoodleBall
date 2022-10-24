using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LevelManagement.Levels

{
    [Serializable]
    public class LevelSpecs
    {
        #region INSPECTOR
        [SerializeField] protected string name;
        [SerializeField] protected string description;
        [SerializeField] protected string sceneName;
        [SerializeField] protected int levelIndex;
        [SerializeField] protected Sprite image;
        [SerializeField] protected Sprite imageLocked;
        #endregion
        #region PROPERTIES
        public string Name => name;
        public string Description => description;
        public string SceneName => sceneName;
        public int LevelIndex => levelIndex;
        public Sprite Image => image;

        public Sprite ImageLocked => imageLocked;
        #endregion
    }

}