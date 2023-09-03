using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cat : MonoBehaviour
{

    Rigidbody2D rb;
    bool isGrounded = false;
    Vector2 movement;
    int groundLayer;
    Transform playerGroundLocation;

    public float playerSpeed = 5;
    public float jumpForce = 1;

    private Action _onFinishedTouched;
    public void Init(Action onFinishTouched)
    {
        _onFinishedTouched = onFinishTouched;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
        playerGroundLocation = transform.Find("PlayerGround");
    }

    private void Update()
    {
        movement = new Vector2();
        if (Input.GetAxis("Horizontal") != 0)
        {
            movement.x = Input.GetAxis("Horizontal");
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            movement.y = 1;
        }
    }
/*
    void OnMove(InputValue iv) {
        movement = iv.Get<Vector2>();
    }*/

    void GroundCheck()
    {
        RaycastHit2D hit;
        float distance = 0.5f;

        hit = Physics2D.Raycast(playerGroundLocation.position, Vector2.down, distance, groundLayer);

        if(hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if isGrounded
        GroundCheck();

        rb.velocity = rb.velocity + (new Vector2(movement.x, 0.0f) * playerSpeed * Time.deltaTime);

        // No horizontal movement, stop velocity if on the ground.
        if(movement.x == 0 && isGrounded == true) {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Can jump
        if(isGrounded && movement.y > 0) {
            //rb.velocity = rb.velocity + (new Vector2(0.0f, (movement.y * jumpForce)) * Time.deltaTime);
            //rb.AddForce(Vector2.up * jumpForce);
            rb.velocity = rb.velocity + Vector2.up * jumpForce;
            Debug.Log("IsGrounded - Jump: " + movement.y);
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (col.CompareTag("Finish"))
        {
            _onFinishedTouched?.Invoke();
            _onFinishedTouched = null;
        }
    }
}