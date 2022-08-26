using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerRopeHandler playerRopeHandler;

    private void Start()
    {
        InputManager.Instance.OnActionStarted += OnAction;
    }

    private void OnAction()
    {
        if (playerRopeHandler.canReleaseRope)
        {
            playerMovement.ReleasingRope();
            playerRopeHandler.ReleaseRope();
            return;
        }

        if(playerRopeHandler.canGrabRope && !playerRopeHandler.canReleaseRope)
        {
            playerMovement.GrabbingRope();
            playerRopeHandler.GrabRope();
            return;
        }

        playerMovement.Jump();
    }
}
