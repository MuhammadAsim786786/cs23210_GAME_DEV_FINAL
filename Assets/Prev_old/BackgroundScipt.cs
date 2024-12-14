using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScipt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
     if (transform.position.x <= -27f)
        {
            transform.position = new Vector3(9.0f, 0, 0);
        }

    }

    void FixedUpdate(){
        transform.Translate(-0.03f,0,0);
    }
}
