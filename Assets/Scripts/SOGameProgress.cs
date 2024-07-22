using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OverForged.GameProgress;

[CreateAssetMenu(fileName = "SOGameProgress", menuName = "ScriptableObjects/GameProgress")]

public class SOGameProgress : ScriptableObject
{
    public int unlockedLevel;
    public Level latestLevel = Level.Flower1;
    public int currentScore;
    public Level currentLevel;
    public enum PlayerSkins
    {
        Default, DefaultBlue, FlowerGardener, FlowerBoy, FlowerBee, ForgeBlacksmith, ForgeAstronaut, ForgeBear
    }
    public PlayerSkins player1Skin = PlayerSkins.Default;
    public PlayerSkins player2Skin = PlayerSkins.DefaultBlue;
    public bool toggleMultiplayer = true;
    public List<bool> skinUnlocked = new(){ true, true, false, false, false, false, false, false };
    public float audioVolume = 1;

    public void EquipSkin1(int skinInt)
    {
        switch (skinInt)
        {
            case 0:
                player1Skin = PlayerSkins.Default; break;
            case 1:
                player1Skin = PlayerSkins.DefaultBlue; break;
            case 2:
                player1Skin = PlayerSkins.FlowerGardener; break;
            case 3:
                player1Skin = PlayerSkins.FlowerBoy; break;
            case 4:
                player1Skin = PlayerSkins.FlowerBee; break;
            case 5:
                player1Skin = PlayerSkins.ForgeBlacksmith; break;
            case 6:
                player1Skin = PlayerSkins.ForgeAstronaut; break;
            case 7:
                player1Skin = PlayerSkins.ForgeBear; break;
        }
    }
    public void EquipSkin2(int skinInt)
    {
        switch (skinInt)
        {
            case 0:
                player2Skin = PlayerSkins.Default; break;
            case 1:
                player2Skin = PlayerSkins.DefaultBlue; break;
            case 2:
                player2Skin = PlayerSkins.FlowerGardener; break;
            case 3:
                player2Skin = PlayerSkins.FlowerBoy; break;
            case 4:
                player2Skin = PlayerSkins.FlowerBee; break;
            case 5:
                player2Skin = PlayerSkins.ForgeBlacksmith; break;
            case 6:
                player2Skin = PlayerSkins.ForgeAstronaut; break;
            case 7:
                player2Skin = PlayerSkins.ForgeBear; break;
        }
    }
}
