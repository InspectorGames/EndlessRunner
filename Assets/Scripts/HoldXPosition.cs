using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldXPosition : MonoBehaviour
{
    public Transform target;
    [Space]
    public Transform transformHold;
    private void Update()
    {
        if(target != null)
        {
            transformHold.position = new Vector3(target.position.x, transformHold.position.y, transformHold.position.z);
        }
    }
}
