using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject player;
    [SerializeField] float weaponSpeed = 5f;
    bool attackOnColdown = false;
    [SerializeField] float weaponOutTimer = 5f;
    bool pickUpAttack = false;
    void OnFire()
    {
        if (attackOnColdown == false)
        {
            GameObject attack = Instantiate(weapon, player.transform.position, transform.rotation);
            Rigidbody2D rb = attack.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * weaponSpeed, ForceMode2D.Impulse);
            attackOnColdown = true;
            pickUpAttack = false;
            Invoke("PickUpAttackReady", weaponOutTimer);

        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon") && pickUpAttack == true)
        {
            attackOnColdown = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon") && pickUpAttack == true)
        {
            attackOnColdown = false;
        }
    }

    void PickUpAttackReady()
    {
        pickUpAttack = true;
    }
}
