using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private float xAxis;
    private bool jumpDown;
    private bool jumpUp;


    public float XAxis { get { return xAxis; } }
    public bool JumpDown { get { return jumpDown; } }
    public bool JumpUp { get { return jumpUp; } }

    public Action OnJumpStarted;
    public Action OnPauseStarted;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        xAxis = ctx.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.phase == InputActionPhase.Started)
        {
            OnJumpStarted?.Invoke();
            jumpDown = true;
            jumpUp = false;
        }
        else if(ctx.phase == InputActionPhase.Canceled)
        {
            jumpDown = false;
            jumpUp = true;
        }
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if(ctx.started) OnPauseStarted?.Invoke();
    }
}
