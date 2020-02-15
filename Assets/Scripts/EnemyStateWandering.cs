using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateWandering : State
{
    // Start is called before the first frame update

    private float timerForChangeDirection = 1;
    private float timerForFlee;

   public EnemyStateWandering(EnemyStateManager theManager):base(theManager)
    {

    }

    public override void Move()
    {
        
        if (timerForChangeDirection <= 0)
        {
            manager.RotateDirection(Random.Range(-50.0f, 50.0f));
            timerForChangeDirection = 1;
        }
        if (timerForFlee <= 0)
        {
            manager.ChangeState(new EnemyStateFleeing(manager));
        }
        if (manager.DetectPlayer())
        {
            manager.ChangeState(new EnemyStateSeeking(manager));
        }
        if (manager.CollideWall())
        {
            manager.ChangeDirection(new Vector3(0,0,0));
            timerForChangeDirection = 1;
            Debug.Log("wall");
        }
        
        timerForChangeDirection -= Time.deltaTime;
        timerForFlee -= Time.deltaTime;
    }

    public override void Appearence()
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        timerForChangeDirection = 1;
        timerForFlee = Random.Range(5.0f,30.0f);
        manager.ChangeColor(new Color(1,1,1));
    }
    public override void Leave()
    {
        base.Leave();
        

    }



}
