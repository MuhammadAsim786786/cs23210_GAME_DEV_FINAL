using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroScript : MonoBehaviour
{
    bool isJumping;
    public GameObject Bullet;

    void Start()
    {
        isJumping = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300)); 
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.01f, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.01f, 0, 0);
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            GameObject newBullet = Instantiate(Bullet, new Vector3(transform.position.x + 0.5f, transform.position.y, 0), Quaternion.identity);
        }
        if(transform.position.y<-4){
            SceneManager.LoadScene("GameOver");
        }
    }

    void FixedUpdate()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Obsta"))
        {
            isJumping = false;
        }
        if (collision.gameObject.name.StartsWith("Enem"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
