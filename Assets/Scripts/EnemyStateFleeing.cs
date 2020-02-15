using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFleeing : State
{
    public EnemyStateFleeing(EnemyStateManager theManager) : base(theManager)
    {

    }
    private float timer;
    

    public override void Move()
    {
        //runaway
        manager.FleePlayer();
        if (timer < 0)
        {
            manager.ChangeState(new EnemyStateWandering(manager));
        }
        timer -= Time.deltaTime;
    }

    public override void Appearence()
    {
        if (timer > 1) {
            manager.ChangeColor(new Color(0, 1, 0)); }
        else
        {
            manager.ChangeColor(new Color(1, 1, 0));
        }
    }

    public override void Enter()
    {   
        timer = 5;
        base.Enter();
    }

    public override void Leave()
    {
        
        base.Leave();
    }

}
