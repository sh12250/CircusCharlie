using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    public float ringSpeed = 0f;
    public float speed = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            transform.Translate(Vector3.left * ringSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
}
