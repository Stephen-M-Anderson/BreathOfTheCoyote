using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is all data for player
[System.Serializable]
public class PlayerData
{
    public float health;
    public float[] playerPosition;
    public float[] playerRotation;
    public bool LeftVillage;
    public bool TrialOfStrength;
    public bool TrialOfMind;
    public bool TrialOfAgility;
    public bool enemies1;
    public bool enemies2;
    public bool enemies3;
    public string saveName;
    public float playTime;
    public string playDate;
    //public Texture2D saveImage;
    public byte[] texData;


    public PlayerData(Player player)
    {
        health = player.health;

        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;

        playerRotation = new float[3];
        playerRotation[0] = player.transform.rotation.x;
        playerRotation[1] = player.transform.rotation.y;
        playerRotation[2] = player.transform.rotation.z;

        LeftVillage = player.LeftVillage;
        TrialOfStrength = player.TrialOfStrength;
        TrialOfMind = player.TrialOfMind;
        TrialOfAgility = player.TrialOfAgility;
        enemies1 = player.enemies1;
        enemies2 = player.enemies2;
        enemies3 = player.enemies3;
        

        saveName = player.saveName;
        playTime = player.playTime;
        playDate = player.playDate;

        //texData = player.saveImage.EncodeToPNG();
        texData = player.texData;
        //saveImage = player.saveImage;
    }
}
