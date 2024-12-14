using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Key_Script : MonoBehaviour
{
    public TextMeshProUGUI Keys_Obtained;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Parse the current text to an integer, increment it, and update the text
            int currentKeys = int.Parse(Keys_Obtained.text);
            currentKeys++;
            if(currentKeys == 7)
            {
                SceneManager.LoadScene("Boss_Scene");
            }
            Keys_Obtained.text = currentKeys.ToString();

            // Destroy the key object
            Destroy(gameObject);
        }
    }
}
