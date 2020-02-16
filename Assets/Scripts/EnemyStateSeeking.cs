using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateSeeking : State
{
    public EnemyStateSeeking(EnemyStateManager theManager) : base(theManager)
    {

    }

    private float timer = 5;
    public override void Move()
    {

        manager.TrackPlayer();
        //Debug.Log("track player");
        if (timer <= 0)
        {
            manager.ChangeState(new EnemyStateWandering(manager));
        }
        timer -= Time.deltaTime;
    }

    public override void Appearence()
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        manager.ChangeColor(new Color(1,0,0));
    }
    public override void Leave()
    {
        base.Leave();
        timer = 5;
    }

}
