using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OverForged.GameProgress;

[CreateAssetMenu(fileName = "SOGameProgress", menuName = "ScriptableObjects/GameProgress")]

public class SOGameProgress : ScriptableObject
{
    public int unlockedLevel;
    public static Level latestLevel = Level.Flower1;
    public static int currentScore;
    public static Level currentLevel;
    public enum PlayerSkins
    {
        Default, FlowerGardener, FlowerBoy, FlowerBee, ForgeBlacksmith, ForgeAstronaut, ForgeBear
    }
    public static PlayerSkins player1Skin = PlayerSkins.Default;
    public static PlayerSkins player2Skin = PlayerSkins.Default;
    public static bool toggleMultiplayer = true;
    public static List<bool> skinUnlocked = new();

    private void OnEnable()
    {
        skinUnlocked.Add(true);
        skinUnlocked.Add(true);
        skinUnlocked.Add(false);
        skinUnlocked.Add(false);
        skinUnlocked.Add(false);
        skinUnlocked.Add(false);
        skinUnlocked.Add(false);
    }

    public static void EquipSkin1(int skinInt)
    {
        switch (skinInt)
        {
            case 0:
                player1Skin = PlayerSkins.Default; break;
            case 1:
                player1Skin = PlayerSkins.FlowerGardener; break;
            case 2:
                player1Skin = PlayerSkins.FlowerBoy; break;
            case 3:
                player1Skin = PlayerSkins.FlowerBee; break;
            case 4:
                player1Skin = PlayerSkins.ForgeBlacksmith; break;
            case 5:
                player1Skin = PlayerSkins.ForgeAstronaut; break;
            case 6:
                player1Skin = PlayerSkins.ForgeBear; break;
        }
    }
    public static void EquipSkin2(int skinInt)
    {
        switch (skinInt)
        {
            case 0:
                player2Skin = PlayerSkins.Default; break;
            case 1:
                player2Skin = PlayerSkins.FlowerGardener; break;
            case 2:
                player2Skin = PlayerSkins.FlowerBoy; break;
            case 3:
                player2Skin = PlayerSkins.FlowerBee; break;
            case 4:
                player2Skin = PlayerSkins.ForgeBlacksmith; break;
            case 5:
                player2Skin = PlayerSkins.ForgeAstronaut; break;
            case 6:
                player2Skin = PlayerSkins.ForgeBear; break;
        }
    }
}
