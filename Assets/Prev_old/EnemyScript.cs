using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;  // For TextMeshPro

public class EnemyScript : MonoBehaviour
{
        

    GameObject Hero;

    void Start()
    {
        // Find the Hero GameObject in the scene
        Hero = GameObject.Find("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        // No code here for now
    }

    void FixedUpdate()
    {
        // Check if the Hero is within a distance of 10 units
        if (Vector3.Distance(Hero.transform.position, transform.position) < 10)
        {
            // Move the enemy faster if close to the Hero
            transform.Translate(-0.08f, 0, 0);
        }
        else
        {
            // Move the enemy slower if farther from the Hero
            transform.Translate(-0.06f, 0, 0);
        }
    }
}
