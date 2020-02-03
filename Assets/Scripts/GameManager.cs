using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject playerObject;
    public Canvas gameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        //playerObject = GameObject.FindWithTag("Player");
        //player = playerObject.GetComponent<Player>();
        player = GameObject.Find("PlayerCharacter").GetComponent<Player>();

        player.saveName = PlayerPrefs.GetString("SaveGameName");

        if (PlayerPrefs.GetInt("NewGame") == 1)
        {
            Debug.LogError("New Game");
            player.NewGame();
            PlayerPrefs.SetInt("NewGame", 0);
        }
        else
        {
            player.LoadGame();
            playerObject.transform.position = player.playerPosition;
        }

        if (player != null)
        {
            //Debug.Log("Found Player");
            player.health = 10;
        }

        player.saveName = PlayerPrefs.GetString("SaveGameName");
        Debug.Log("Save Game Name: " + player.saveName);

        //Scene scene = SceneManager.GetActiveScene();
        //Debug.Log("Active Scene is '" + scene.name + "'.");

        
        
    }
    /*
    // Update is called once per frame
    void Update()
    {
        //SetupMenus();

        if(player.health == 0)
        {
            //GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }

    public void GameWin()
    {
        Debug.Log("YOU WIN!");
    }
    */
    
}
