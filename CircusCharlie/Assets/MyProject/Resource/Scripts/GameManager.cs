using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;

    private void Awake()
    {
        if (!instance.IsValid())
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
