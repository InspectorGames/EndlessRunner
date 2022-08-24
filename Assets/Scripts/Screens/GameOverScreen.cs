using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public static Action OnRestart;
    public void OnRestartButton()
    {
        OnRestart?.Invoke();
    }
}
