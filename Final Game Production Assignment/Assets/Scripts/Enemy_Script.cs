using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    private GameObject player;
    private float playerDistance; // current distance from player
    public GameObject enemySpriteOrigin;
    public float detectionDistance; // how far from us does player need to be for attack
    public float speed;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        playerDistance = Vector2.Distance(transform.position, player.transform.position);
        if (playerDistance <= detectionDistance)
        {
            Vector3 targ = player.transform.position - transform.position;
            targ.z = 0f;
            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            enemySpriteOrigin.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -transform.rotation.z));

            transform.position += transform.right * Time.deltaTime * speed;
        }
    }

}
