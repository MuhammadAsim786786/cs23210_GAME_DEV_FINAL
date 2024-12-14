using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player_Combat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public GameObject healthBar;
    public GameObject Bullet;
    public GameObject Boss;
    public int max_Bullets = 15;
    public TextMeshProUGUI Max_BulletText;
    public AudioSource attackAudioSource;
    public AudioSource bulletAudio;
    public AudioSource otherAudioSource;

    private Health_Bar_Script healthBarScript;
    private bool isGameOver = false; 

    public float attackRange = 0.5f;
    public float destroyDelay = 0.5f;
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        healthBarScript = healthBar.GetComponent<Health_Bar_Script>();
        if (healthBarScript == null)
        {
            Debug.LogError("Health_Bar_Script not found on the healthBar GameObject!");
            return;
        }
        currentHealth = maxHealth;
        healthBarScript.SetMaxHealth(maxHealth);

        if (Max_BulletText != null)
        {
            Max_BulletText.text = max_Bullets.ToString();
        }
        else
        {
            Debug.LogError("Max_BulletText is not assigned in the Inspector!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            registerDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        if (max_Bullets > 0)
        {
            max_Bullets--;
            Max_BulletText.text =max_Bullets.ToString();
            bulletAudio.Play();
            Instantiate(Bullet, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, 0), Quaternion.identity);
        }
        else
        {
            Debug.Log("No bullets left!");
        }
    }

    public void registerDamage(int damage)
    {
        if (isGameOver) return;
        otherAudioSource.Play();
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); 
        healthBarScript.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            isGameOver = true;
            SceneManager.LoadScene("GameOver");
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        attackAudioSource.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " has been hit!");

            if (Boss != null)
            {
                Boss.GetComponent<BossHealth>().TakeDamage(10);
            }
            else
            {
                Debug.LogError("Boss reference is missing!");
                StartCoroutine(DestroyEnemyWithDelay(enemy.gameObject));
            }
        }
    }

    IEnumerator DestroyEnemyWithDelay(GameObject enemy)
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(enemy);
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
