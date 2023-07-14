using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.anyKey)
        {
            GFunc.LoadScene("Stage1Scene");
            return;
        }
    }
}
