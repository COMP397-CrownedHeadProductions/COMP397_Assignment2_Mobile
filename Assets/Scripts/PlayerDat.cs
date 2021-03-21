using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDat
{
    public float playerHealthSaved;
    public float[] playerPosSaved;

    public PlayerDat(PlayerController player)
    {
        playerHealthSaved = player.currentHealth;
        playerPosSaved = new float[3];
        playerPosSaved[0] = player.transform.position.x;
        playerPosSaved[1] = player.transform.position.y;
        playerPosSaved[2] = player.transform.position.z;
    }
}
