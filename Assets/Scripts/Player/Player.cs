﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool LeftVillage;
    public bool TrialOfStrength;
    public bool TrialOfMind;
    public bool TrialOfAgility;
    public bool enemies1;
    public bool enemies2;
    public bool enemies3;
    public Vector3 playerPosition;
    public Quaternion playerRotation;
    public string saveName;
    public float playTime = 0.0f;
    public string playDate;
    //public Texture2D saveImage;
    public byte[] texData;
    public PlayerUI PlayerUI;

    private AudioSource deathSource;
    private AudioSource hitSource;
    private bool playdead;

    //grabbing audio
    private void Start()
    {
        deathSource = GameObject.Find("PlayerDeath").GetComponent<AudioSource>();
        hitSource = GameObject.Find("PlayerHit").GetComponent<AudioSource>();
        playdead = true;
        maxHealth = health;
    }

    private void Update()
    {
        //player should be dead
        // THIS IS NOT WORKING PROPERLY FIND OUT WHY
        if (health <= 0 && playdead)
        {
            hitSource = null;
            deathSource.Play();
            GetComponent<Animator>().SetBool("Death", true);
            GetComponent<PlayerCharacterController>().enabled = false;
            GetComponent<KeyCombo>().enabled = false;
            playdead = false;
        }
    }

    private void ReloadDeath()
    {
        SceneManager.LoadScene("Game Scene");
    }
   
    //Sets everything needed for the new game
    public void NewGame()
    {
        health = 10;
        LeftVillage = false;
        TrialOfStrength = false;
        TrialOfMind = false;
        TrialOfAgility = false;
        enemies1 = false;
        enemies2 = false;
        enemies3 = false;
        playTime = 0.0f;

        Debug.Log("[PLAYER] Creating new game: " + saveName);

        SaveSystem.NewPlayerData(this);
    }

    //This is our save game system. Saves data and takes screenshot of last game scene
    public void SaveGame()
    {
        playDate = DateTime.Now.ToString();
        playTime = Time.timeSinceLevelLoad;
        //saveImage = ScreenCapture.CaptureScreenshotAsTexture();
        //texData = saveImage.EncodeToPNG();
        //texData = ScreenCapture.CaptureScreenshotAsTexture().EncodeToPNG();

        Debug.Log("[PLAYER] Play Date: " + playDate);
        Debug.Log("[PLAYER] Play Time: " + playTime);

        SaveSystem.SavePlayerData(this);
    }

    //This loads up the game data from the save chosen
    public void LoadGame()
    {
        
        PlayerData data = SaveSystem.LoadPlayerData(saveName);

        health = data.health;
        LeftVillage = data.LeftVillage;
        TrialOfStrength = data.TrialOfStrength;
        TrialOfMind = data.TrialOfMind;
        TrialOfAgility = data.TrialOfAgility;
        enemies1 = data.enemies1;
        enemies2 = data.enemies2;
        enemies3 = data.enemies3;
        saveName = data.saveName;
        playTime = data.playTime;
        playDate = data.playDate;

        playerPosition.x = data.playerPosition[0];
        playerPosition.y = data.playerPosition[1];
        playerPosition.z = data.playerPosition[2];

        playerRotation.x = data.playerRotation[0];
        playerRotation.y = data.playerRotation[1];
        playerRotation.z = data.playerRotation[2];

        //saveImage.LoadImage(data.texData);
        //texData = data.texData;
    }

    //The damage script for the player. Runs the sound of taking damage, the damage subtraction and updating the UI to reflect damage taken
    public void DamagePlayer(int damage)
    {
        hitSource.Play();
        health -= damage;
        //Debug.Log("Damage: " + health);
        PlayerUI.UpdateSlider(health);
    }

    public void HealPlayer(int healing)
    {
        if (health + healing >= maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healing;
        }
        PlayerUI.UpdateSlider(health);
    }
}
