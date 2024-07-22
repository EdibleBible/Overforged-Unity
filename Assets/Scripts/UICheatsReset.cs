using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SOGameProgress;

public class UICheatsReset : MonoBehaviour
{
    public SOGameProgress progress;

    public void Reset()
    {
        progress.latestLevel = OverForged.GameProgress.Level.Flower1;
        progress.currentScore = 0;
        progress.player1Skin = PlayerSkins.Default;
        progress.player2Skin = PlayerSkins.DefaultBlue;
        progress.toggleMultiplayer = true;
        progress.skinUnlocked[0] = true;
        progress.skinUnlocked[1] = true;
        progress.skinUnlocked[2] = false;
        progress.skinUnlocked[3] = false;
        progress.skinUnlocked[4] = false;
        progress.skinUnlocked[5] = false;
        progress.skinUnlocked[6] = false;
        progress.skinUnlocked[7] = false;
        SceneManager.LoadScene(0);
    }

    public void UnlockLevels()
    {
        progress.latestLevel = OverForged.GameProgress.Level.Forge3;
    }

    public void UnlockSkins()
    {
        progress.skinUnlocked[0] = true;
        progress.skinUnlocked[1] = true;
        progress.skinUnlocked[2] = true;
        progress.skinUnlocked[3] = true;
        progress.skinUnlocked[4] = true;
        progress.skinUnlocked[5] = true;
        progress.skinUnlocked[6] = true;
        progress.skinUnlocked[7] = true;
    }
}
