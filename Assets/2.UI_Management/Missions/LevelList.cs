using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Levels

{
    [CreateAssetMenu(fileName ="LevelList", menuName = "Levels/Create LevelList", order = 1)]
    public class LevelList : ScriptableObject
    {
        #region INSPECTOR
        [SerializeField] private List<LevelSpecs> levels;
        #endregion
        #region PROPERTIES
        public int TotalLevels => levels.Count;
        #endregion
        public LevelSpecs GetLevel(int index)
        {
            return levels[index];
        }
    }

}