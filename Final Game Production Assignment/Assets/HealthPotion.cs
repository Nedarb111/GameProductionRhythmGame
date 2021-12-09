using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetInt("healthPotionNum") > 0)
            {
                PlayerPrefs.SetInt("healthPotionNum", PlayerPrefs.GetInt("healthPotionNum") + 1);
            }
            else
            {
                PlayerPrefs.SetInt("healthPotionNum", 1);
            }
        }

        Destroy(gameObject);
    }
}
