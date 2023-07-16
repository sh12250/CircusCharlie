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

    void Start()
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
