using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Script : MonoBehaviour
{
    public AudioSource tickSource;

    void Start()
    {
        tickSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tickSource.Play();
            SceneManager.LoadScene(1);
        }
    }

}
