using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Source File: PauseController.cs
 * Editors: Peitong Liu and Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 03-21-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 *                       Alpha - 2021-03-08
 * - Pause menu UI implemented
 * - Pause functionality implemented
 * - Load and Save button UI added
 * - Resume and Back to Menu button added and functional
 * 
 *                        Beta - 2021-03-21
 * - Save and load player and enemy data implemented(WIP)
 * - Converted UI keyboard press to on screen buttons for mobile application
 * 
 */

public class PauseController : MonoBehaviour
{
    /// <summary>
    /// Pause can only be done by pressing esc in
    /// the game but resume can be done by both 
    /// pressing esc or the resume button.
    /// </summary>
    /// 
    public bool isPaused=false;
    public GameObject PauseMenuUI;
    public List<MonoBehaviour> scripts;
    public List<MonoBehaviour> enemyScripts;

    [Header("Player")]
    public PlayerController player;
    public CameraController playerCamera;

    [Header("Enemy")]
    public ChaseEnemyController[] chaseEnem;
    public ChaseEnemyController[] chaseHealth;
    public RangeEnemyController[] rngEnem;
    public RangeEnemyController[] rHealth;

    [Header("Scene")]
    public SceneDataSO sceneData;

    void Start()
    {
        ResumeGame();
        playerCamera = FindObjectOfType<CameraController>();
        player = FindObjectOfType<PlayerController>();
        chaseEnem = FindObjectsOfType<ChaseEnemyController>();
        rngEnem = FindObjectsOfType<RangeEnemyController>();

        //Deserialize and loading our Data from Player Preferences
        var sceneDataJSONString = PlayerPrefs.GetString("playerData");
        JsonUtility.FromJsonOverwrite(sceneDataJSONString, sceneData);
    }
    // Update is called once per frame
    void Update()
    {
        //Pause Menu Function
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (isPaused)
            {
                ResumeGame();
                //Cursor.lockState = CursorLockMode.Locked;
                playerCamera.enabled = true;
            }
            else
            {
                PauseGame();
                playerCamera.enabled = false;
            }
        }
        if (isPaused == true)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                ToMenu();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResumeGame();
                playerCamera.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                OnSaveButtonPressed();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                OnLoadButtonPressed();
            }
        }
    }

    void TogglePaused()
    {
        if (isPaused)
        {
            ResumeGame();
            //Cursor.lockState = CursorLockMode.Locked;
            playerCamera.enabled = true;
        }
        else
        {
            PauseGame();
            playerCamera.enabled = false;
        }
        if (isPaused == true)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                ToMenu();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResumeGame();
                playerCamera.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                OnSaveButtonPressed();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                OnLoadButtonPressed();
            }
        }
    }

    void LoadGame()
    {
        //sceneData = JsonUtility.FromJson<SceneDataSO>(PlayerPrefs.GetString("playerData")); 
        player.controller.enabled = false;
        player.transform.position = sceneData.playerPosition;
        player.transform.rotation = sceneData.playerRotation;
        playerCamera.transform.position = sceneData.cameraPosition;
        playerCamera.transform.rotation = sceneData.cameraRotation;
        player.currentHealth = sceneData.playerHealth;
        player.healthBar.SetHealth(sceneData.playerHealth);
        player.controller.enabled = true;
        //Load Chase Enemy Position, Rotation and Health
        foreach (var chaseEnemy in chaseEnem)
        {
            chaseEnemy.transform.position = sceneData.chaseEnemPos;
            chaseEnemy.transform.rotation = sceneData.chaseEnemRot;
            chaseEnemy.health = sceneData.chaseEnemHealth;
        }

        //Load Range Enemy Position, Rotation and Health
        foreach (var rangeEnemy in rngEnem)
        {
            rangeEnemy.transform.position = sceneData.rangeEnemPos;
            rangeEnemy.transform.rotation = sceneData.rangeEnemRot;
            rangeEnemy.rHealth = sceneData.rangeEnemHealth;
        }
        Debug.Log("Load Game Successful");
    }
    
    void SaveGame()
    {
        sceneData.playerPosition = player.transform.position;
        sceneData.playerRotation = player.transform.rotation;
        sceneData.cameraRotation = playerCamera.transform.rotation;
        sceneData.cameraPosition = playerCamera.transform.position;
        sceneData.playerHealth = player.currentHealth;

        //Save Chase Enemy Position, Rotation and Health
        foreach (var chaseEnemy in chaseEnem)
        {
            sceneData.chaseEnemPos = chaseEnemy.transform.position;
            sceneData.chaseEnemRot = chaseEnemy.transform.rotation;
            sceneData.chaseEnemHealth = chaseEnemy.health;
        }

        //Save Range Enemy Position, Rotation and Health
        foreach (var rangeEnemy in rngEnem)
        {
            sceneData.rangeEnemPos = rangeEnemy.transform.position;
            sceneData.rangeEnemRot = rangeEnemy.transform.rotation;
            sceneData.rangeEnemHealth = rangeEnemy.rHealth;
        }
        Debug.Log("Save Game Successful");
        // Serialize and Save our data to Player Preferences dictionary/db
        PlayerPrefs.SetString("playerData", JsonUtility.ToJson(sceneData));
    }

    void ResumeGame()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        PauseMenuUI.SetActive(false);        
        Time.timeScale = 1f;
        isPaused = false;
        foreach (var script in scripts)
        {
            script.enabled = isPaused;
        }
        //player.controller.enabled = true;
        Debug.Log("Resume");
    }

    void PauseGame()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        foreach (var script in scripts)
        {
            script.enabled = !isPaused;
        }
        player.controller.enabled = false;
        Debug.Log("Pause");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void OnResumeButtonPressed()
    {
        ResumeGame();
        playerCamera.enabled = true;
        player.controller.enabled = true;
    }

    public void OnPauseButtonPressed()
    {
        TogglePaused();
        playerCamera.enabled = true;
        player.controller.enabled = true;
    }

    public void OnLoadButtonPressed()
    {
        LoadGame();
        player.controller.enabled = true;
    }

    public void OnSaveButtonPressed()
    {
        SaveGame();
    }
}
