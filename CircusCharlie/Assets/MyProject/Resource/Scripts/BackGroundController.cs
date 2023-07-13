using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public float xLeftEnd = -2560f;
    public float xRightEnd = 2560f;

    public float speed = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.localPosition.x <= xLeftEnd)
        {
            GoToTheRight();
        }

        if (transform.localPosition.x >= xRightEnd)
        {
            GoToTheLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void GoToTheRight()
    {
        Vector2 offset = new Vector2(xRightEnd * 1.5f, 0f);
        transform.localPosition = transform.localPosition.AddVectors(offset);
    }

    private void GoToTheLeft()
    {
        Vector2 offset = new Vector2(xLeftEnd * 1.5f, 0f);
        transform.localPosition = transform.localPosition.AddVectors(offset);
    }
}
