using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private void FixedUpdate()
    {
        transform.position = new Vector3(0, player.transform.position.y, -10);
    }
}
