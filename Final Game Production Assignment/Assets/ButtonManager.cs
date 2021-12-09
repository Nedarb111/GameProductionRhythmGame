using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject pointer;

    private int arrayLength;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        arrayLength = buttons.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentIndex > 0) // up
        {
            currentIndex--;
            pointer.transform.position = buttons[currentIndex].transform.position - Vector3.right * 1.6f;
        }
        if (Input.GetKeyDown(KeyCode.S) && currentIndex < arrayLength) // down
        {
            currentIndex++;
            pointer.transform.position = buttons[currentIndex].transform.position - Vector3.right * 1.6f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // WARNING, HARD CODE BELOW IT WILL BE MESSY
            if (currentIndex == 0) // health potion
            {
                Debug.Log("tyring to use health potion\n");
                if (PlayerPrefs.GetInt("healthPotionNum") > 0)
                {
                    Debug.Log("used health potion\n");
                    Debug.Log(PlayerPrefs.GetInt("healthPotionNum") + " poitions left\n");
                    GameObject.Find("GameManager").GetComponent<GameManager>().GainHealth();
                    PlayerPrefs.SetInt("healthPotionNum", PlayerPrefs.GetInt("healthPotionNum") - 1);
                }
            }
            else // 1/2 speed
            {

            }
        }
    }
}
