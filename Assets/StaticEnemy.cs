using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a tag of "Player"
        if (collision.gameObject.tag == "Player")
        {
            
            Player.GetComponent<Player_Combat>().registerDamage(10);
            
        }
    }
}
