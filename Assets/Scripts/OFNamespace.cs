using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OverForged
{
    public class GameProgress: MonoBehaviour
    {
        public enum Level
        {
            MainMenu, Test, LevelSelect, LevelUI, LevelFinishedUI, LevelFailedUI, Flower1, Flower2, Flower3, Forge1, Forge2, Forge3, Extra1
        }
        public delegate void ProgressUI(ItemInteract item);
        public static event ProgressUI ProgressEvent;
        public delegate void ProgressTime(float duration);
        public static event ProgressTime ProgressTimeEvent;
        public delegate Level LevelDel();
        public static event LevelDel GetLevelEvent;
        public delegate int ScoreDel();
        public static event ScoreDel GetScoreEvent;

        public static void UpdateProgress(ItemInteract item)
        {
            ProgressEvent?.Invoke(item);
        }

        public static void UpdateTime(float duration)
        {
            ProgressTimeEvent?.Invoke(duration);
        }

        public static Level GetLevel()
        {
            return GetLevelEvent.Invoke();
        }

        public static int GetScore()
        {
            return GetScoreEvent.Invoke();
        }
    }
}
