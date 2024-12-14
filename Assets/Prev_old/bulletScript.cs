using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Player;
    private float temp;

    void Start()
    {
        Boss = GameObject.Find("Boss");
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        print(Player.transform.localScale.x); 

        if (Player.transform.localScale.x > 0)
        {
            temp = -1f; 
        }
        else
        {
            temp = 1f; 
        }


        Vector3 direction = new(0.2f , 0, 0);
        print(direction);
        transform.Translate(direction);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Ene"))  
        {
            Destroy(collision.gameObject);  
            Destroy(gameObject);  
        }
        else if (collision.gameObject.name.StartsWith("Boss"))
        {
            print("Boss");
            if (Boss != null)
            {
                print("Boss");
                Boss.GetComponent<BossHealth>().TakeDamage(10);
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);  
        }
    }
}

