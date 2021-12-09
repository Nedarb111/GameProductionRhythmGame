using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    bool obtained = false;

    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
      if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                //GameManager.instance.NoteHit();
                

                if(Mathf.Abs(transform.position.y) > 0.25)
                {
                    GameManager.instance.NormalHit();
                    Debug.Log("Normal");
                    obtained = true;
                    Instantiate(goodEffect, transform.position, hitEffect.transform.rotation);
                }
                else if(Mathf.Abs(transform.position.y) > 0.05f)
                {
                    GameManager.instance.GoodHit();
                    Debug.Log("Good");
                    obtained = true;
                    Instantiate(goodEffect, transform.position, hitEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    obtained = true;
                    Instantiate(goodEffect, transform.position, perfectEffect.transform.rotation);
                }
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
            if (other.tag == "Activator")
            {
                canBePressed = false;
                if (!obtained)
                {
                GameManager.instance.NoteMissed();
                Instantiate(goodEffect, transform.position, missEffect.transform.rotation);
            }
            }
    }
}
