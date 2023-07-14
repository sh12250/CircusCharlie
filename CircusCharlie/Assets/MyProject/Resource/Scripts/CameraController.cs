using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player = default;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x < 8.1f)
        {
            transform.position = new Vector3(player.transform.position.x + 6, transform.position.y, transform.position.z);
        }
    }
}
