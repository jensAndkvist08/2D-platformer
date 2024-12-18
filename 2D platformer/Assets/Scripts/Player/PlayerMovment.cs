using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpSpeed = 10F;
    [SerializeField] ContactFilter2D groundFilter;
    [SerializeField] float timeTilLoadExit = 1f;

    Rigidbody2D rb;

    bool isGrounded;

    Vector2 moveInput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

    }
    void OnJump()
    {
        if (isGrounded == true)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = rb.IsTouching(groundFilter);
    }

    void Update()
    {
        rb.velocity = new Vector2((moveInput.x * moveSpeed), rb.velocity.y);
        if (moveInput.x != 0)
        {
            transform.localScale = new Vector2(moveInput.x, transform.localScale.y);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exit"))
        {
            Invoke("Quit", timeTilLoadExit);
        }
    }
    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }
}
