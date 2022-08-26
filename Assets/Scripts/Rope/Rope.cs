using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D ropeBody;

    private void Start()
    {
        ropeBody.gravityScale = 0;
    }

    public void PlayerGrabbed()
    {
        ropeBody.gravityScale = 1;
    }
}
