using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SOGameProgress;

public class UICheatsReset : MonoBehaviour
{

    public void Reset()
    {
        SOGameProgress.latestLevel = OverForged.GameProgress.Level.Flower1;
        SOGameProgress.currentScore = 0;
        SOGameProgress.player1Skin = PlayerSkins.Default;
        SOGameProgress.player2Skin = PlayerSkins.DefaultBlue;
        SOGameProgress.toggleMultiplayer = true;
        SOGameProgress.skinUnlocked[0] = true;
        SOGameProgress.skinUnlocked[1] = true;
        SOGameProgress.skinUnlocked[2] = false;
        SOGameProgress.skinUnlocked[3] = false;
        SOGameProgress.skinUnlocked[4] = false;
        SOGameProgress.skinUnlocked[5] = false;
        SOGameProgress.skinUnlocked[6] = false;
        SOGameProgress.skinUnlocked[7] = false;
        SceneManager.LoadScene(0);
    }

    public void UnlockLevels()
    {
        SOGameProgress.latestLevel = OverForged.GameProgress.Level.Forge3;
    }

    public void UnlockSkins()
    {
        SOGameProgress.skinUnlocked[0] = true;
        SOGameProgress.skinUnlocked[1] = true;
        SOGameProgress.skinUnlocked[2] = true;
        SOGameProgress.skinUnlocked[3] = true;
        SOGameProgress.skinUnlocked[4] = true;
        SOGameProgress.skinUnlocked[5] = true;
        SOGameProgress.skinUnlocked[6] = true;
        SOGameProgress.skinUnlocked[7] = true;
    }
}
