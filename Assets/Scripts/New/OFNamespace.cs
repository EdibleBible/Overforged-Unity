using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OverForged
{
    public class GameProgress: MonoBehaviour
    {
        public delegate void ProgressUI(ItemInteract item);
        public static event ProgressUI ProgressEvent;

        public static void UpdateProgress(ItemInteract item)
        {
            ProgressEvent?.Invoke(item);
        }
    }
}
