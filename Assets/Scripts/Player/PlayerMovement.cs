using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;


    public float jumpVelocity;
    public float speed;

    public float releaseRopeVelocity;

    public Transform upPosition;
    public Transform downPosition;
    private Vector3 desiredPosition;

    private bool isDown;
    private bool canJump = true;
    private bool isGrabbingRope = false;
    private bool isReleasingRope = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        InputManager.Instance.OnActionStarted += Jump;

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

        if(isReleasingRope)
        {
            transform.position = new Vector3(transform.position.x, Vector3.MoveTowards(transform.position, downPosition.position, releaseRopeVelocity / 10).y, transform.position.z);

            if((transform.position.y <= downPosition.position.y + 0.5f))
            {
                isReleasingRope = false;
                isDown = true;
            }
        }
    }

    private void FixedUpdate()
    {
        //if (isGrabbingRope) return;
        rb.velocity = transform.right * speed * Time.fixedDeltaTime;
    }

    public void Jump()
    {
        if (isReleasingRope) return;
        if (isGrabbingRope) return;
        if (!canJump) return;

        if (isDown)
        {
            isDown = false;
            desiredPosition = upPosition.position;
        }
        else
        {
            isDown = true;
            desiredPosition = downPosition.position;
        }

        canJump = false;
    }
    
    public void GrabbingRope()
    {
        isGrabbingRope = true;
        rb.gravityScale = 1;
    }

    public void ReleasingRope()
    {
        isGrabbingRope = false;
        isReleasingRope = true;
        rb.gravityScale = 0;
    }
}
