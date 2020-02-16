using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentGameStates : MonoBehaviour
{
}

public class Playing : GameState
{
    public Playing(GameStateManager theGameStateManager) : base(theGameStateManager)
    {

    }

    public override void stateBehavior()
    {
        if (gameStateManager.PlayerDie()) //no player left
        {
            //lose
            gameStateManager.ChangeState(new YouLose(gameStateManager));
        }
        else if (gameStateManager.EnemyCount() <= 0) // no enemy left
        {
            //win
            gameStateManager.ChangeState(new Victory(gameStateManager));
        }
    }

    public override void Enter()
    {
        base.Enter();
        //health to full
        gameStateManager.SetHealthFull();
        //spawn player
        gameStateManager.SpawnPlayer();
        //spawn enemy
        gameStateManager.SpawnEnemy(Random.Range(4,11));
        GameStateManager.readyToStartGame = false;
        //

    }
    public override void Leave()
    {
        base.Leave();
        gameStateManager.DeletePlayer();
        gameStateManager.DeleteAllEnemy();
    }
}


public class Victory : GameState
{
    public Victory(GameStateManager theGameStateManager) : base(theGameStateManager)
    {

    }

    public override void stateBehavior()
    {
        if (GameStateManager.readyToStartGame)
        {
            gameStateManager.ChangeState(new Playing(gameStateManager));
        }
    }

    public override void Enter()
    {
        base.Enter();
        // show end game screen;
        gameStateManager.OpenEndGameScreen();
        gameStateManager.SetEndGameText("Victory");
    }
    public override void Leave()
    {
        base.Leave();
        //disable endgameScreen
        gameStateManager.CloseEndGameScreen();
    }
}

public class YouLose : GameState
{
    public YouLose(GameStateManager theGameStateManager) : base(theGameStateManager)
    {
        if (GameStateManager.readyToStartGame)
        {
            gameStateManager.ChangeState(new Playing(gameStateManager));
        }
    }

    public override void stateBehavior()
    {
        if (GameStateManager.readyToStartGame)
        {
            gameStateManager.ChangeState(new Playing(gameStateManager));
        }
    }

    public override void Enter()
    {
        base.Enter();
        // show end game screen;
        gameStateManager.OpenEndGameScreen();
        gameStateManager.SetEndGameText("You Lose");
    }
    public override void Leave()
    {
        base.Leave();
        //disable endGameScreen
        gameStateManager.CloseEndGameScreen();
    }
}
