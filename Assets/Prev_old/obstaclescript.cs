using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclescript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        transform.Translate(-0.06f,0,0);
    }
}
