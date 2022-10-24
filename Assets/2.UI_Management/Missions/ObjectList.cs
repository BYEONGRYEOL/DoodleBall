using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace LevelManagement.Levels

{

    [CreateAssetMenu(fileName = "ObjectList", menuName = "Objects/Create ObjectList", order = 2)]
    public class ObjectList : ScriptableObject
    {
        [SerializeField] public List<MissionObject> objects;
        public int TotalObjects => objects.Count;
        public MissionObject GetLevel(int index)
        {
            return objects[index];
        }
        public MissionObject BuildIndexToLevelIndex()
        {
            int a;
            a = SceneManager.GetActiveScene().buildIndex;
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].SceneIndex == a)
                {
                    return objects[i];
                }
            }
            return null;
        }

    }
}