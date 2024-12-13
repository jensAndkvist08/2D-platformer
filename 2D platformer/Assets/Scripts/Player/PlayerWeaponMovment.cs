using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponMovment : MonoBehaviour
{
    [SerializeField] float comeBackTimer = 3f;
    [SerializeField] float weaponSpeed = 5f;
    GameObject player;
    Rigidbody2D rb;
    bool comeBack = false;
    bool comingBack = false;
    void Start()
    {
        Invoke("ComeBack", comeBackTimer);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (comeBack == true)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * weaponSpeed * Time.fixedDeltaTime);
            comingBack = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (comingBack == true)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
       if(comingBack == true)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        } 
    }
    void ComeBack()
    {
        comeBack = true;
    }
}
