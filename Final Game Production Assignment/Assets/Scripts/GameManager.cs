using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public healthBar UIHealthbar;
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int Player_Health = 20;
    public int healthPerNormalNote = 0;
    public int healthPerGoodNote = 0;
    public int healthPerPerfectNote = 1;

    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UIHealthbar.SetPlayerHealth(Player_Health);
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
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

    public void NormalHit()
    {
        currentHealth += healthPerNormalNote;
        NoteHit();
    }
    public void GoodHit()
    {
        currentHealth += healthPerGoodNote;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentHealth += healthPerPerfectNote;
        NoteHit();
    }


    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        Player_Health = Player_Health - healthPerPerfectNote;
        Debug.Log(Player_Health);

        if(Player_Health <= 0)
        {
            Player_Health = 0;
        }

        UIHealthbar.SetPlayerHealth(Player_Health);
    }

    public void GainHealth()
    {
        Player_Health += 7;
        UIHealthbar.SetPlayerHealth(Player_Health);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("healthPotionNum", 0);
    }

}
