using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    private GameState currentGameState;
    public GameObject enemy;
    public GameObject Player;
    public GameObject EndGameScreen;
    public TextMeshProUGUI EndGameText;
    public static bool readyToStartGame = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new Playing(this));
    }

    // Update is called once per frame
    void Update()
    {
        currentGameState.stateBehavior();
    }


    public void ChangeState(GameState newGameState)
    {
        if (currentGameState != null) currentGameState.Leave();
        currentGameState = newGameState;
        currentGameState.Enter();
    }

    public void SpawnEnemy(int spawnAmount)
    {
        for (int i = 0; i < spawnAmount; i++)
        {

            Vector3 location = new Vector3(Random.Range(-7.8f, 7.8f), Random.Range(-3.8f, 3.8f));
            while (Vector2.Distance(location,new Vector2(0,0)) < 3.0f)
            {
                location = new Vector3(Random.Range(-7.8f, 7.8f), Random.Range(-3.8f, 3.8f));
            }
            Instantiate(enemy, location, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
        }
    }
    public void SpawnPlayer()
    {
        Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void DeleteAllEnemy()
    {
        foreach (GameObject survivedEnemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(survivedEnemy);
        }

    }

    public void DeletePlayer()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    public void StartGame()
    {
        readyToStartGame = true;
    }
    public void SetHealthFull()
    {
        PlayerController.health = 3;
    }

    public void CloseEndGameScreen()
    {
        EndGameScreen.SetActive(false);
    }
    public void OpenEndGameScreen(){
        EndGameScreen.SetActive(true);
        }
    public void SetEndGameText(string EndText)
    {
        EndGameText.text = EndText;
    }

    public bool PlayerDie()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            return true;
        }
        else return false;
    }

    public int EnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
       
    }
}
