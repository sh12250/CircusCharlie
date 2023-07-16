using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;
    public AudioClip audioClip_stageBGM;
    public AudioClip audioClip_death;
    public AudioClip audioClip_win;

    private void Awake()
    {
        if (!instance.IsValid())
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("씬에 두개 이상의 게임 매니져가 존재합니다");
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }
}
