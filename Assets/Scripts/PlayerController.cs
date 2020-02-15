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
        heart.fillMethod = Image.FillMethod.Radial360; 
        heart.fillAmount = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
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
}
