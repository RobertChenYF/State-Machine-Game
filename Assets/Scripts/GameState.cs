using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    // Start is called before the first frame update
    protected GameStateManager gameStateManager;


    public abstract void stateBehavior();
    public virtual void Enter()
    {

    } // Virtual so can be overriden in derived classes.
    public virtual void Leave()
    {


    }


    public GameState(GameStateManager theGameStateManager) // Constructor that takes an argument.
    {
       gameStateManager = theGameStateManager;
    }
}
