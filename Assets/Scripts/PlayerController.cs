using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    private Image heart;
    public static int health = 3;
    public Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        heart = GameObject.Find("heart").GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(health);
        heart.fillAmount = health/3.0f;

        if (Input.GetAxis("Horizontal") > 0)
        {
            player.velocity = new Vector2(velocity, player.velocity.y);

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            player.velocity = new Vector2(-velocity, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            player.velocity = new Vector2(player.velocity.x, velocity);
        }
        else if (Input.GetAxis("Vertical")<0)
        {
            player.velocity = new Vector2(player.velocity.x, -velocity);
        }
        else
        {
            player.velocity = new Vector2(player.velocity.x ,0);
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            string CurrentState = collision.gameObject.GetComponent<EnemyStateManager>().ReturnCurrentState();
            Destroy(collision.gameObject);
            if (CurrentState.Equals("EnemyStateFleeing") == false)
            {
                health -= 1;
            }
            if (health == 0)
            {
                Debug.Log("game over");
                Destroy(gameObject);
            }
        }
    }
}
