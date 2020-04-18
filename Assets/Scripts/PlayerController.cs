using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private int moveSpeed = 15;
    [SerializeField] private int jumpForce = 50;
    [SerializeField] private LayerMask ground;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private Vector2 moveDirection;

    private bool isJumping;
    [SerializeField] private bool isGrounded;
    [SerializeField] private int jumpCount;

    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        moveDirection = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, 0);
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, ground);
        Debug.DrawRay(transform.position, Vector2.down);
        if (isGrounded) jumpCount = 2;

        if (moveDirection.x < 0) {
            spriteRenderer.flipX = true;
        } else if (moveDirection.x > 0) {
            spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;
        }
    }

    private void FixedUpdate() {


        MovePlayer();

        if (isJumping && jumpCount > 0) {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = false;
            jumpCount--;
        }
    }

    private void MovePlayer() {
        moveDirection.y = rigidBody.velocity.y;
        rigidBody.velocity = moveDirection;
    }
}
