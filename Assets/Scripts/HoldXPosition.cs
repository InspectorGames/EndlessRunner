using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldXPosition : MonoBehaviour
{
    public Transform target;
    [Space]
    public Transform upPosition;
    public Transform downPosition;
    private void Update()
    {
        upPosition.position = new Vector3(target.position.x, upPosition.position.y, upPosition.position.z);
        downPosition.position = new Vector3(target.position.x, downPosition.position.y, downPosition.position.z);
    }
}
