using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{
    public float moveSpeed = 5f;

    public SpriteRenderer spriterenderer;
    public Rigidbody2D rb;
    //public Animator animator;

    Vector2 movement;

    private void Start()
    {
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        // This is if you have a float in an animator you want to change if moving 
       // animator.SetFloat("Speed", movement.sqrMagnitude);

        // Flip player when x change, use only if you want
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) // idle
        {
            GetComponent<Animator>().SetBool("walking", false);
        }
        else // moving
        {
            GetComponent<Animator>().SetBool("walking", true);

            if (Input.GetAxis("Horizontal") < 0)
            {
                spriterenderer.flipX = true;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                spriterenderer.flipX = false;
            }
        }

        transform.localScale = characterScale;

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<AudioSource>().Play();
            SceneManager.LoadScene(1);
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("healthPotionNum", 0);
    }

}
