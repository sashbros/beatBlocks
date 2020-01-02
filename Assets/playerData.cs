using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData
{
    // populate data here levels name hardcoded ?
    public int[,] data = new int[,] {
        {0, 0, 0, 0, 1}, //levelIndex, bestScore, maxCombo, stars, locked
        {1, 0, 0, 0, 1},
        {2, 0, 0, 0, 1},
        {3, 0, 0, 0, 1},
        {4, 0, 0, 0, 1},
        {5, 0, 0, 0, 1},
        {6, 0, 0, 0, 1},
        {7, 0, 0, 0, 1},
        {8, 0, 0, 0, 1},
        {9, 0, 0, 0, 1},
        {10, 0, 0, 0, 1},
        {11, 0, 0, 0, 1},
    };
    // public int[,] data = new int[12,5];

    // data[x][0] levelIndex
    // data[x][1] bestScore;
    // data[x][2] maxCombo;
    // data[x][3] stars;
    // data[x][4] locked = 0/1; 0=locked 1=unlocked

    public playerData(playerController player) {
        data[player.levelIndex, 0] = player.levelIndex;
        data[player.levelIndex, 1] = player.blocksCollected;
        data[player.levelIndex, 2] = player.maxComboCount;
        data[player.levelIndex, 3] = player.totalStars;
        data[player.levelIndex, 4] = 1;
    }

   
}
