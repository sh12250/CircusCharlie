using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotController : MonoBehaviour
{
    public float speed = 0f;

    public GameObject joyStickHandle = default;

    private float distance = 35.58f;

    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.x < -10f)
        {
            Vector2 offset = new Vector2(distance, 0);
            transform.position = transform.position.AddVectors(offset);
        }

        if (!GameManager.instance.isGameOver)
        {
            // if (Input.GetKey(KeyCode.RightArrow))
            if (joyStickHandle.transform.localPosition.x > 0)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            // else if (Input.GetKey(KeyCode.LeftArrow))
            else if (joyStickHandle.transform.localPosition.x < 0)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
}
