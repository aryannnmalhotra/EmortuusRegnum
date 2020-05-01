using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform PlayerPosition;
    private void LateUpdate()
    {
        Vector3 newPosition = PlayerPosition.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90, PlayerPosition.eulerAngles.y, 0);
    }
}
