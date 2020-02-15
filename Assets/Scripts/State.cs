using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected EnemyStateManager manager; // The manager that contains the state machine.
    
    public abstract void Move(); // This is abstract so it MUST be implemented in derived classes.
    public abstract void Appearence();

    public virtual void Enter() {
       
    } // Virtual so can be overriden in derived classes.
    public virtual void Leave() { 
    
    
    }

    public State(EnemyStateManager theManager) // Constructor that takes an argument.
    {
        manager = theManager;
    }

}
