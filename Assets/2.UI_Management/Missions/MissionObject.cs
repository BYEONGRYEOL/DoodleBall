using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Levels
{
    [Serializable]
    public class MissionObject
    {
        public string sceneName;
        public int sceneIndex;
        public int levelIndex;
        public float ink_Line;
        public float ink_LineWithGravity;
        public float ink_LineUp;
        public float ink_LineWithAccel;
        public float inkLeftRatioForStar;
        public bool inkStar;
        public float timeLimitForStar;
        public bool timeStar;
        public bool isUnlock;
        public bool isCleared;
        public int starCollected;

        public string SceneName => sceneName;
        public int SceneIndex => sceneIndex;
        public int LevelIndex => levelIndex;
        public float Ink_Line => ink_Line;
        public float Ink_LineWithGravity => ink_LineWithGravity;

        public float Ink_LineUp => ink_LineUp;

        public float Ink_LineWithAccel => ink_LineWithAccel;

        public float InkLeftRatioForStar { get => inkLeftRatioForStar; set => inkLeftRatioForStar = value; }
        public bool InkStar {get => inkStar; set => inkStar = value; }
        public float TimeLimitForStar => timeLimitForStar;
        public bool TimeStar { get => timeStar; set => timeStar = value; }
        public bool IsUnlock { get => isUnlock; set => isUnlock = value; }
        public bool IsCleared { get => isCleared; set => isCleared = value; }
        public int StarCollected { get => starCollected; set => starCollected = value; }

        public MissionObject()
        {
            sceneName = default;
            sceneIndex = default;
            levelIndex = default;
            ink_Line = 0f;
            ink_LineWithGravity = 0f;
            ink_LineUp = 0f;
            ink_LineWithAccel = 0f;
            inkLeftRatioForStar = default;
            inkStar = false;
            timeLimitForStar = default;
            timeStar = false;
            isUnlock = false;
            isCleared = false;
            starCollected = 0;
        }
    }

}