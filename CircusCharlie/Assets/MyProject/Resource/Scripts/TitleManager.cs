using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameData gameData;

    void Start()
    {

    }

    void Update()
    {
        if (Input.anyKey)
        {
            gameData.life = 3;

            GFunc.LoadScene("StageScene");
            return;
        }
    }
}
