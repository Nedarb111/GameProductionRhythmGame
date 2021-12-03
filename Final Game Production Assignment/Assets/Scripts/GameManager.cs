using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public TextMeshProUGUI healthtext;

    public int Player_Health = 20;
    public int healthPerNote = 1;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        healthtext.text = "Health: " + Player_Health;

    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }

        if (startPlaying == true && theMusic.isPlaying == false)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");
    }
    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        Player_Health = Player_Health - healthPerNote;
        healthtext.text = "Health: " + Player_Health;
        Debug.Log(Player_Health);

        if(Player_Health <= 0)
        {
            Player_Health = 0;
        }
    }

}
