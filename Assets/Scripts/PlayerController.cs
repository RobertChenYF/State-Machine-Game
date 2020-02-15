using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public Image heart;
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        heart.fillAmount = health/3.0f;

        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += new Vector3(velocity*Time.deltaTime, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += new Vector3(-velocity * Time.deltaTime, 0, 0);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += new Vector3(0, velocity * Time.deltaTime, 0);
        }
        else if (Input.GetAxis("Vertical")<0)
        {
            transform.position += new Vector3(0, -velocity * Time.deltaTime, 0);
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
