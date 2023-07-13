using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    public float xLeftEnd = -2560f;
    public float xRightEnd = 2560f;

    void Start()
    {

    }

    void Update()
    {
        if(gameObject.transform.position.x <= xLeftEnd)
        {
            GFunc.Log("���ʳ�");
            GoToTheRight();
        }
        if(gameObject.transform.position.x >= xRightEnd)
        {
            GFunc.Log("�����ʳ�");
            GoToTheLeft();
        }
    }

    private void GoToTheRight()
    {
        Vector2 offset = new Vector2(xRightEnd, 0f);
        gameObject.transform.position = gameObject.transform.position.AddVectors(offset);
    }

    private void GoToTheLeft()
    {
        Vector2 offset = new Vector2(xLeftEnd, 0f);
        gameObject.transform.position = gameObject.transform.position.AddVectors(offset);
    }
}
