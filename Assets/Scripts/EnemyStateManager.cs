using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public BoxCollider2D detection;
    
    public PolygonCollider2D body;
    protected GameObject player;
    protected CircleCollider2D playerCollider;
    private State currentState;
    public Rigidbody2D rigidbodyOfEnemy;
    private float velocity = 1;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCollider = player.GetComponent<CircleCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        ChangeState(new EnemyStateWandering(this));
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Move();
        currentState.Appearence();
        rigidbodyOfEnemy.velocity = transform.up * velocity;
    }


    public void ChangeState(State newState)
    {
        if (currentState != null) currentState.Leave();
        currentState = newState;
        currentState.Enter();
    }
    public bool DetectPlayer()
    {
        return (detection.IsTouching(playerCollider));
    }
    public void ChangeDirection(Vector3 target)
    {
        transform.up = target - transform.position;
    }

    public void RotateDirection(float angle)
    {
        transform.Rotate(0,0, angle, Space.Self);
    }
    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }
    public bool CollideWall()
    {
        return (body.IsTouchingLayers(LayerMask.GetMask("Wall")));
    }
    public void TrackPlayer()
    {
        transform.up = player.transform.position - transform.position;
    }
    public void FleePlayer()
    {
        transform.up = transform.position - player.transform.position;
    }

    public State getCurrentState()
    {
        return currentState;
    }
    
}
