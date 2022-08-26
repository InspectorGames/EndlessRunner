using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRopeHandler : MonoBehaviour
{
    public HingeJoint2D joint;
    public bool canGrabRope = false;
    public bool canReleaseRope = false;
    private Rigidbody2D ropeRb;

    private void Start()
    {
        joint.enabled = false;
    }

    public void GrabRope()
    {
        joint.enabled = true;
        joint.connectedBody = ropeRb;
        ropeRb.GetComponentInParent<Rope>().PlayerGrabbed();
        canReleaseRope = true;
    }

    public void ReleaseRope()
    {
        joint.enabled = false;
        canReleaseRope = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rope"))
        {
            canGrabRope = true;
            ropeRb = collision.GetComponentInParent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Rope"))
        {
            canGrabRope = false;
        }
    }
}
