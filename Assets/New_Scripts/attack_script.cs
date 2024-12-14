using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_script : MonoBehaviour
{
    public GameObject player;              // Assign this in the Inspector
    public Animator animator;              // Assign this in the Inspector
    public float attackRange = 10f;
    public float attackCooldown = 1.5f;
    private float lastAttackTime = 0f;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player GameObject is not assigned in the Inspector!");
        }

            if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("Animator not assigned or found on the GameObject.");
            }
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        if (Vector3.Distance(player.transform.position, transform.position) < attackRange)
        {
            transform.Translate(-0.008f, 0, 0);

            if (Time.time >= lastAttackTime + attackCooldown)
            {
                StartCoroutine(PerformAttack());
                lastAttackTime = Time.time;
            }
        }
        else
        {
            transform.Translate(-0.006f, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            player.GetComponent<Player_Combat>().registerDamage(10);

        }
    }

    IEnumerator PerformAttack()
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.2f); 
     
    }
}
