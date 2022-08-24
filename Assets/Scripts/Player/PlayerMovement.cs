using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float jumpVelocity;
    public float speed;

    public Transform upPosition;
    public Transform downPosition;
    private Vector3 desiredPosition;

    private Vector3 sideValue;

    private bool isDown;
    private bool canJump = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        InputManager.Instance.OnJumpStarted += Jump;

        transform.position = downPosition.position;
        isDown = (transform.position == downPosition.position);
    }

    private void Update()
    {
        if (!canJump)
        {
            transform.position = new Vector3(transform.position.x, Vector3.MoveTowards(transform.position, desiredPosition, jumpVelocity / 10).y, transform.position.z);

            canJump = (isDown && transform.position.y <= desiredPosition.y + 0.5f) || (!isDown && transform.position.y >= desiredPosition.y - 0.5f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed * Time.fixedDeltaTime;
    }

    private void Jump()
    {
        if (!canJump) return;

        if (isDown)
        {
            isDown = false;
            sideValue = transform.up;
            desiredPosition = upPosition.position;
        }
        else
        {
            isDown = true;
            sideValue = -transform.up;
            desiredPosition = downPosition.position;
        }

        canJump = false;
    }
}
