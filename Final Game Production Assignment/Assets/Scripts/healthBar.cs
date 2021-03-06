using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    private int playerStartHealth = 100; // dummy value
    private int playerHealth = 0;

    private float currentXVal = 1f;
    private float goalXVal = 1f;
    private bool lerping = false;
    private float lerpCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (lerping)
        //{
        //    lerpCounter += Time.deltaTime * 3f;
        //    goalXVal = (float)playerHealth / (float)playerStartHealth;
        //    transform.localScale = new Vector3(Mathf.Lerp(currentXVal, goalXVal, Mathf.Clamp(lerpCounter, 0f, 1f)), transform.localScale.y, transform.localScale.z);
        //    if (transform.localScale.x <= goalXVal)
        //    {
        //        currentXVal = goalXVal;
        //        lerping = false;
        //    }
        //}
    }

    public void SetPlayerHealth(int newHealth)
    {
        //lerping = false;
        //transform.localScale = new Vector3(goalXVal, transform.localScale.y, transform.localScale.z);
        //currentXVal = goalXVal;

        if (playerStartHealth == 100) // hasn't been set
            playerStartHealth = newHealth;
        playerHealth = (int)Mathf.Clamp(newHealth, 0f, playerStartHealth);
        transform.localScale = new Vector3((float)newHealth / (float)playerStartHealth, transform.localScale.y, transform.localScale.z);
        //lerpCounter = 0f;
        //lerp = true;
    }
}
