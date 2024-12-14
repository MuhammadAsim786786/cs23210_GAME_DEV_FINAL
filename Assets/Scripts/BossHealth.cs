using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{

	public int health = 500;

	public GameObject deathEffect;
	public GameObject Win_Wall;
	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 200)
		{
			GetComponent<Animator>().SetBool("isEnraged", true);
		}

		if (health <= 0)
		{
			Die();
			
		}
	}

	void Die()
	{
		Destroy(Win_Wall);
		Destroy(gameObject);
	}

}
