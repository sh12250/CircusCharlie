using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameData gameData;
    //public AudioSource titleAudio;
    //public AudioClip startBGM;

    void Start()
    {
        //if (!titleAudio.clip)
        //{
        //    titleAudio.clip = startBGM;
        //}
    }

    void Update()
    {
        if (Input.anyKey)
        {
            gameData.life = 3;
            //titleAudio.Play();
            GFunc.LoadScene("StageScene");
            return;
        }
    }
}
