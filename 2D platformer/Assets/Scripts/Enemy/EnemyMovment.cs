using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    [SerializeField] float enemyFlipDealy = 1f;
    [SerializeField] float enemySpeed = 5f;
    bool cantFilp = false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(enemySpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enemySpeed = -enemySpeed;
            FlipSprite();
        }
        else if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (cantFilp == false)
        {
            enemySpeed = -enemySpeed;
            FlipSprite();
            cantFilp = true;
            Invoke("CanFlip", enemyFlipDealy);
        }
    }
    void FlipSprite()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

    }

    void CanFlip()
    {
        cantFilp = false;
    }
}
