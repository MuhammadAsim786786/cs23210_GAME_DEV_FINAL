using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FlagScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void OnCollisionEnter2D(Collision2D collision2D)
{
    
    if(collision2D.gameObject.name.StartsWith("Her"))
    {
        SceneManager.LoadScene("Win Screen");
    }
}

}