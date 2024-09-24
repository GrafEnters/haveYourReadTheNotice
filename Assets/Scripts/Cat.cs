using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cat : MonoBehaviour {
    [SerializeField]
    private MovementConfig _movementConfig;

    private Action _onFinishedTouched;
    private Action _onJump;
    int groundLayer;
    bool isGrounded = false;
    private bool isJumping = false;
    Vector2 movement;
    Transform playerGroundLocation;
    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
        playerGroundLocation = transform.Find("PlayerGround");
    }

    private void Update() {
        movement = new Vector2();
        if (Input.GetAxis("Horizontal") != 0) {
            movement.x = Input.GetAxis("Horizontal");
        }

        if (Input.GetKey(KeyCode.Space)) {
            movement.y = 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        // Check if isGrounded
        GroundCheck();

        rb.linearVelocity = rb.linearVelocity + (new Vector2(movement.x, 0.0f) * _movementConfig.HorAcceleration * Time.deltaTime);

        // No horizontal movement, stop velocity if on the ground.
        if (movement.x == 0 && isGrounded == true) {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        // Can jump
        if (isGrounded && movement.y > 0 && !isJumping) {
            Jump();
        }

        ClampSpeed();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Respawn")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (col.CompareTag("Finish")) {
            _onFinishedTouched?.Invoke();
            _onFinishedTouched = null;
        }
    }

    public void Init(Action onFinishTouched, Action onJump) {
        _onFinishedTouched = onFinishTouched;
        _onJump = onJump;
    }
/*
    void OnMove(InputValue iv) {
        movement = iv.Get<Vector2>();
    }*/

    void GroundCheck() {
        RaycastHit2D hit;
        float distance = 0.5f;

        hit = Physics2D.Raycast(playerGroundLocation.position, Vector2.down, distance, groundLayer);

        if (hit.collider != null) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }

    private void Jump() {
        //rb.velocity = rb.velocity + (new Vector2(0.0f, (movement.y * jumpForce)) * Time.deltaTime);
        //rb.AddForce(Vector2.up * jumpForce);
        rb.linearVelocity = rb.linearVelocity + Vector2.up * _movementConfig.JumpForce;
        StartCoroutine(JumpCoroutine());
        Debug.Log("IsGrounded - Jump: " + movement.y);
        isGrounded = false;
        _onJump?.Invoke();
    }

    private IEnumerator JumpCoroutine() {
        isJumping = true;
        yield return new WaitForSeconds(0.1f);
        isJumping = false;
    }

    private void ClampSpeed() {
        Vector2 tmp = rb.linearVelocity;
        tmp.x = Mathf.Clamp(tmp.x, -_movementConfig.MaxHorSpeed, _movementConfig.MaxHorSpeed);
        tmp.y = Mathf.Clamp(tmp.y, -_movementConfig.MaxVertSpeed, _movementConfig.MaxVertSpeed);
        rb.linearVelocity = tmp;
    }
}